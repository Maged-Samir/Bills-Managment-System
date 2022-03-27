
using System.Collections.Generic;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class StockCountController : Controller
    {
        IItemRepository itemServices;
        ITypeRepository typeServices;
        public StockCountController(IItemRepository itemRepo, ITypeRepository typeRepo)
        {
            itemServices = itemRepo;
            typeServices = typeRepo;
        }
        public IActionResult stockscount()
        {
            List<Type> types = typeServices.GetAll();
            ViewData["types"] = types;
            return View(new Item());
        }
        [HttpPost]
        public IActionResult stockscount(int typeId)
        {
            List<Item> items = itemServices.GetItemsInSpaceficType(typeId);
            List<Type> types = typeServices.GetAll();
            ViewData["types"] = types;
            ViewData["items"] = items;

            return View("stockscount", itemServices.GetById(typeId));
        }
    }
}
