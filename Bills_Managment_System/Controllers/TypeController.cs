using System.Collections.Generic;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class TypeController : Controller
    {
        ICompanyRepository compServices;
        ITypeRepository typeServices;

        public TypeController(ICompanyRepository compRepo, ITypeRepository typeRepo)//inject 
        {
            compServices = compRepo;
            typeServices = typeRepo;

        }
        
        // Dispaly Main View Of Addition
        public IActionResult Add()
        {
            Type Newtype = new Type();
            List<Company> Companies = compServices.GetAll();
            ViewData["comp"] = Companies;
            return View(Newtype);
        }

        //Save Additional Data 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Type Newtype)
        {
            if (ModelState.IsValid == true)
            {
                {
                    typeServices.Insert(Newtype);
                    TempData["Test"] = "Type Saved Successfully ";
                    return RedirectToAction("Add");
                }
            }
            return View("Add",Newtype);
        }

        //Cheak Type Name Is Unique Using Remote Validation
        public IActionResult UniqueTypeName(string name)
        {
            Type type = typeServices.GetByName(name);
            if (type == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

    }
}
