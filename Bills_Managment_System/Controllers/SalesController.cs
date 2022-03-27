using System.Collections.Generic;
using System.Linq;
using Bills.Data;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bills.Controllers
{
    public static class SessionExtensions
    {
        //Session Extention for Setting Obj on Session by Serialization
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        //Session Extention For Getting Obj from Session by Desrialization
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class SalesController : Controller
    {
        IItemRepository itemServices;
        IItemDetailsRepository itemDetailsServices;
        ISalesRepository salesServices;
        IClientRepository clientServices;

        public SalesController(ISalesRepository salesRepo,IItemRepository itemRepo,IClientRepository clientRepo, IItemDetailsRepository itemDetailsRepo)
        {
            itemServices = itemRepo;
            clientServices = clientRepo;
            itemDetailsServices = itemDetailsRepo;
            salesServices = salesRepo;
        }
        
        public IActionResult SaveItem(SalesDetalis item)
        {
            //Display Data In Table
            List<SalesDetalis> objsComplex = new List<SalesDetalis>();//to show table data for items added
            List<Item> itemsforTable = new List<Item>();//for more details in the table            
            List<float> totals = new List<float>();//to show total for one item in the table

            float total = 0;
            if (ModelState.IsValid)
            {
                // to get from session
                SalesDetalis objComplex = new SalesDetalis();
                
                for (int i = 0; i < 10; i++)
                {
                    //to check objComlex if null
                    objComplex = HttpContext.Session.GetObject<SalesDetalis>($"ComplexObject{i}");
                    if (objComplex == null)
                    {
                        //set sales details to session
                        HttpContext.Session.SetObject($"ComplexObject{i}", item);
                        //calculate total bill
                        objComplex = HttpContext.Session.GetObject<SalesDetalis>($"ComplexObject{i}");
                        objsComplex.Add(objComplex);
                        
                        itemsforTable.Add(itemServices.GetById(objComplex.Item_Id));//get item by id to display in the table
                        total += objComplex.Price * objComplex.quantity;
                        totals.Add(objComplex.Price * objComplex.quantity);

                        ViewData["allTotals"] = totals;//total for each item in the table
                        ViewData["MoreDetailsTableItem"] = itemsforTable;//more details for the item
                       
                        ViewData["TableItems"] = objsComplex;//for table data
                        ViewData["total"] = total;//for total bill
                        ViewData["clients"] = clientServices.GetAll();
                        ViewData["items"] = itemServices.GetAll();
                        
                        return View("Add", new Sales());
                    }
                    //Calculate Total Bill Of Previous Items
                    total += objComplex.Price * objComplex.quantity;
                    objsComplex.Add(objComplex);//for table data
                    itemsforTable.Add(itemServices.GetById(objComplex.Item_Id));//for more details
                    totals.Add(objComplex.Price * objComplex.quantity);//total for each item in the table
                }

            }
            ViewData["total"] = total;//to reset total to zero
            ViewData["clients"] = clientServices.GetAll();
            ViewData["items"] = itemServices.GetAll();
            return View("Add", new Sales());
        }

        //Partial View For Selected Item Price
        public IActionResult ItemPriceDetails(int item_id)
        {
            Item item = itemServices.GetById(item_id);
            ViewData["item"] = item;
            return PartialView("_ItemPrice",item);
        }
        public IActionResult Add()
        {
            ViewData["clients"]= clientServices.GetAll();
            ViewData["items"] = itemServices.GetAll();

            ViewData["item"] = new SalesDetalis();//for validation of id items form
            return View(new Sales());
        }
        
        [HttpPost]
        public IActionResult Add(Sales sales)
        {
            if (ModelState.IsValid)
            {
                //to save from session to database
                List<SalesDetalis> objsComplex = new List<SalesDetalis>();
                SalesDetalis objComplex = new SalesDetalis();
                for (int i = 0; i < 10; i++)
                {
                    objComplex = HttpContext.Session.GetObject<SalesDetalis>($"ComplexObject{i}");
                    if (objComplex != null)
                    {
                        objsComplex.Add(HttpContext.Session.GetObject<SalesDetalis>($"ComplexObject{i}"));
                        HttpContext.Session.SetObject($"ComplexObject{i}", null);//to make session empty
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                salesServices.Insert(sales);//save Bill in sales table
                int sales_id = salesServices.GetSalesId();//get id for new row in table sales
                foreach (SalesDetalis i in objsComplex)//loop for each item in items added in the Bill
                {
                    i.Sales_Id = sales_id;//add sales details to the Bill (add sales id to each item)
                    itemDetailsServices.Insert(i);//add sales details to the database
                    // update beginning quantity
                    Item it= itemServices.GetById(i.Item_Id);
                    it.Stock -= i.quantity;
                    itemServices.Update(it.Id, it);

                }
                TempData["Test"] = "Sales Invoice Saved Successfully";
                return RedirectToAction("Add");
            }
            ViewData["clients"] = clientServices.GetAll();
            ViewData["items"] = itemServices.GetAll();
            return View("Add", sales);
        }
        //Generating Bill Number 
        public IActionResult GenerateSalesNumber()
        {
            int? number = salesServices.GetNumber();
            if (number == null)
                ViewData["number"] = 1;
            ViewData["number"] = ++number;
            return PartialView("_PartialGenerateSalesNumber");
        }
        //selling quantity must be less than stock
        public IActionResult TestQuantity(int quantity, int Item_Id)
        {
            Item item = itemServices.GetById(Item_Id);
            if (item.Stock>quantity)
            {
                return Json(true);
            }
            else
                return Json(false);
        }
        //validation for paied must be less than net
        public IActionResult TestPaied(float paied, float total, float disvalue)
        {
            if (paied <= (total - disvalue))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
