using System.Collections.Generic;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class ItemController : Controller
    {
        IItemRepository itemServices;
        ICompanyRepository compServices;
        ITypeRepository typeServices;
        IUnitRepository unitServices;
        public ItemController(IItemRepository itemRepo, ICompanyRepository compRepo, ITypeRepository typeRepo, IUnitRepository unitRepo)//inject 
        {
            itemServices = itemRepo;
            compServices = compRepo;
            typeServices = typeRepo;
            unitServices = unitRepo;
        }
        
        //Display Main View Of Addition
        public IActionResult Add()
        {
            //Fill DropDown List Of Companies
            List <Company> comp = compServices.GetAll();
            ViewData["comps"] = comp;
            //Fill DropDown List Of Unites
            List<Unit> unit = unitServices.GetAll();
            ViewData["units"] = unit;
            return View(new Item());
        }
        //Get Types Of Selected Company
        public IActionResult TypeDetails(int com_id)
        {
            List<Type> type = typeServices.GetAll(com_id);
            ViewData["types"] = type;
            return PartialView("_TypeSelect");
        }
        //Save Data Of New Item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Item newItem)
        {
            if (ModelState.IsValid)
            {
                itemServices.Insert(newItem);
                TempData["Test"] = "Item Inserted Successfully";
                return RedirectToAction("Add");
            }
            return View("Add", newItem);
        }
        //Cheak that Buying Price Less than Selling Price
        public IActionResult TestPrice(int SellingPrice, int BuyingPrice)
        {
            if (BuyingPrice < SellingPrice)
            {
                return Json(true);
            }

            return Json(false);
        }
        //Cheak that Item Name Is Unique 
        public IActionResult TestItemName(string Name)
        {
            Item item = itemServices.GetByName(Name);
            if (item == null)
            {
                return Json(true);
            }
            else
                return Json(false);
        }
    }
}
