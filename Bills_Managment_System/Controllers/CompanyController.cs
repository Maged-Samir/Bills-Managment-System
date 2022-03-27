using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyRepository compServices;

        public CompanyController( ICompanyRepository compRepo)
        {
            compServices = compRepo;
        }
        
        //Display Main View Of Addition
        public IActionResult Add()
        {
            return View();
        }

        //Save Addition Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Company com)
        {
            if (ModelState.IsValid == true)
            {
                {
                    compServices.Insert(com);
                    TempData["Test"] = "Company Added successfully";
                    return RedirectToAction("Add");
                }
            }

            return View("Add", com);
        }

        //Cheak that Company Name is Unique
        public IActionResult uniquename(string name)
        {
            Company company = compServices.GetByName(name);
            if (company == null)
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
