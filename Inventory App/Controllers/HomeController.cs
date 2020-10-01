using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Inventory_App.Models;
using Inventory_App.Logic;
using Inventory_App.ViewModel;

namespace Inventory_App.Controllers
{
    public class HomeController : Controller
    {
        #region Dependancy Injection
        private readonly ILogger<HomeController> _logger;
        private readonly IBusinessLogic _businessLogic;
        private readonly IUpdateItem _updateItem;
        private readonly IManufactureItem _manufactureItem;

        public HomeController(ILogger<HomeController> logger, IBusinessLogic BusinessLogic, IUpdateItem updateItem, IManufactureItem manufactureItem)
        {
            _logger = logger;
            _businessLogic = BusinessLogic;
            _updateItem = updateItem;
            _manufactureItem = manufactureItem;
        }
        #endregion

        public IActionResult Index()
        {
            List<StockItems> a = _businessLogic.GetStockItems();

            return View(a);
        }

        public IActionResult Item(int id)
        {
            var item = _businessLogic.GetMaterial(id);

            return View(item);
        }

        public IActionResult NewEntry(NewEntryVM vm)
        {
            return View(vm);
        }

        [HttpPost]
        public IActionResult NewEntryPost(int id,NewEntryVM vm)
        {
            if (vm == null) throw new Exception("Model cannot be empty");

            if (id == 0)
            {
                _businessLogic.CreateNewEntry(vm);
            }
            else
            {
                _businessLogic.UpdateEntry(id, vm);
            }

            return Json(new { stockId = vm.StockItems.Id, materialId = vm.Materials.Id });
        }

        [HttpPut]
        public IActionResult EditStockItem(int id, StockItemVM vm)
        {
            if (vm == null) throw new Exception("Model cannot be empty");

            _updateItem.UpdateStockItemVM(vm);

            return Json(new { materialId = vm.Id });
        }
        [HttpPut]
        public IActionResult EditItem(int id, MaterialVM vm)
        {
            if (vm == null) throw new Exception("Model cannot be empty");

            _updateItem.UpdateMaterial(vm);

            return Json(new { materialId = vm.Id });
        }

        public IActionResult ManufacturePortal()
        {
            ViewBag.StockItems = _businessLogic.GetStockItems();
            ManufactureVM manufactureVM = new ManufactureVM();

            return View(manufactureVM);
        }

        [HttpPost]
        public IActionResult Manufacture(int id, ManufactureVM vM)
        {
            List<string> status = _manufactureItem.Manufacture(id, vM);

            if (status.Count > 0) return Json(status);

            return Json("Done");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
