using Inventory_App.Models;
using Inventory_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_App.Logic
{
    public class BusinessLogic : IBusinessLogic
    {
        #region Dependency Injection
        private readonly DataContext _context;
        private readonly IUpdateItem _updateItem;

        public BusinessLogic(DataContext context, IUpdateItem updateItem)
        {
            _context = context;
            _updateItem = updateItem;
        }
        #endregion

        public List<StockItems> GetStockItems()
        {
            return _context.StockItems.ToList();
        }
        public List<StockItems> GetStockItem(int id)
        {
            return _context.StockItems.Where(c => c.Id == id).ToList();
        }

        public List<Materials> GetMaterial(int id)
        {
            List<StockMaterials> LookupList = _context.StockMaterials.Where(c => c.StockItemId == id).ToList();
            List<Materials> MaterialsNeeded = new List<Materials>();

            foreach (var item in LookupList)
            {
                var tempItem = _context.Materials.Where(c => c.Id == item.MaterialId).FirstOrDefault();

                MaterialsNeeded.Add(tempItem);
            }

            return MaterialsNeeded;
        }

        public NewEntryVM CreateNewEntry(NewEntryVM vm)
        {
            _context.StockItems.Add(vm.StockItems);
            _context.Materials.Add(vm.Materials);

            _context.SaveChanges(); // changes are saved to context to update the Id fields

            StockMaterials stockMaterials = new StockMaterials
            {
                StockItemId = vm.StockItems.Id,
                MaterialId = vm.Materials.Id
            };

            _context.StockMaterials.Add(stockMaterials);

            _context.SaveChanges();

            return vm;
        }

        public NewEntryVM UpdateEntry(int id, NewEntryVM vm)
        {
            try
            {
                _updateItem.UpdateStockItem(vm.StockItems);

                //_updateItem.UpdateMaterial(vm.Materials);
                vm.Materials.Id = 0;

                _context.Materials.Add(vm.Materials);
                _context.SaveChanges();

                StockMaterials stockMaterials = new StockMaterials
                {
                    StockItemId = vm.StockItems.Id,
                    MaterialId = vm.Materials.Id
                };

                _context.StockMaterials.Add(stockMaterials);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Beep();
            }
            return vm;
        }
    }
}
