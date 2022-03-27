using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{

    public class ClientController : Controller
    {
        IClientRepository clientServices;
        public ClientController(IClientRepository clientRepo)
        {
            clientServices = clientRepo;
        }
        //Display Main View 
        public IActionResult Add()
        {
            return View(new Client());
        }
        //Save Data Of Client 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Client newClient)
        {
            if (ModelState.IsValid == true)
            {
                clientServices.Insert(newClient);
                TempData["Test"] = "Client Saved Succsefully";
                return RedirectToAction("Add");
            }
            return View("Add", newClient);
        }
        //Cheak Uniqueness Of Client Name
        public IActionResult UniqueName(string Name)
        {
            Client client = (Client)clientServices.GetByName(Name);
            if (client == null)
            {
                return Json(true);
            }
            else
                return Json(false);
        }
        //Generating Client Number
        public IActionResult GenerateClientNumber()
        {
            int? number = clientServices.GetNumber();
            if (number == null)
                ViewData["number"] = 1;
                ViewData["number"] = ++number;
            return PartialView("_PartialGenerateClientNumber");

        }
    }
}
