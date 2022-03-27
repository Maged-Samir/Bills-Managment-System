using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class UnitController : Controller
    {
        
        IUnitRepository unitServices;

        public UnitController(IUnitRepository unitRepo)
        {
            unitServices = unitRepo;
        }
       //Dispaly Main View 
        public IActionResult Add()
        {
            return View();
        }
       //Save Unite Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Unit unit)
        {
            if (ModelState.IsValid == true)
            {
                    unitServices.Insert(unit);
                    TempData["Test"] = "Successfully Add Unit";
                    return RedirectToAction("Add");
            }
            return View("Add", unit);
        }
        //Cheak that Entered Unite Is Unique 
        public IActionResult uniquename(string name)
        {
            Unit unit = unitServices.GetByName(name);
            if (unit == null)
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
