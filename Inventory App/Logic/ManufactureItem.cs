using Inventory_App.Models;
using Inventory_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_App.Logic
{
    public class ManufactureItem : IManufactureItem
    {
        #region Dependency Injection
        private readonly DataContext _context;
        private readonly IUpdateItem _updateItem;

        public ManufactureItem(DataContext context, IUpdateItem updateItem)
        {
            _context = context;
            _updateItem = updateItem;
        }
        #endregion

        public List<string> Manufacture(int id, ManufactureVM vM)
        {
            var StockItem = _context.StockItems.Find(id);
            List<StockMaterials> LookupList = _context.StockMaterials.Where(c => c.StockItemId == id).ToList();
            List<string> Errors = new List<string>();

            foreach (var item in LookupList)
            {
                var tempItem = _context.Materials.Where(c => c.Id == item.MaterialId).FirstOrDefault();

                if (tempItem.Quantity < vM.Qty)
                {
                    Errors.Add("Insufficient " + tempItem.Description);
                }
                else
                {
                    tempItem.Quantity = Convert.ToInt32( tempItem.Quantity - vM.Qty);
                    
                    if (Errors.Count == 0) _context.SaveChanges();

                }
            }
            StockItem.Quantity = Convert.ToInt32(StockItem.Quantity + vM.Qty);
            _context.SaveChanges();

            return Errors;
        }


    }
}
