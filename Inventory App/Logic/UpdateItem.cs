using Inventory_App.Models;
using Inventory_App.ViewModel;
using System;
using System.Linq;

namespace Inventory_App.Logic
{
    public class UpdateItem : IUpdateItem
    {
        #region Dependancy Injection
        private readonly DataContext _context;

        public UpdateItem(DataContext context)
        {
            _context = context;
        }
        #endregion

        public void UpdateStockItem(StockItems StockItems)
        {
            var DBrecord = _context.StockItems.Find(StockItems.Id);

            if (StockItems != null)
            {
                DBrecord.ItemName = StockItems.ItemName == null || StockItems.ItemName == "" ? DBrecord.ItemName : StockItems.ItemName;
                DBrecord.Description = StockItems.Description == null || StockItems.Description == "" ? DBrecord.Description : StockItems.Description;
                DBrecord.Quantity = StockItems.Quantity;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMsg = e.ToString();
            }

        }

        public void UpdateMaterial(MaterialVM Materials)
        {
            var DBrecord = _context.Materials.Find(Materials.Id);

            if (Materials != null)
            {
                DBrecord.Description = Materials.Description == null || Materials.Description == "" ? DBrecord.Description : Materials.Description;
                DBrecord.Quantity = Materials.Quantity;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }

        }

        public void UpdateStockItemVM(StockItemVM StockItems)
        {
            var DBrecord = _context.StockItems.Find(StockItems.Id);

            if (StockItems != null)
            {
                DBrecord.ItemName = StockItems.ItemName == null || StockItems.ItemName == "" ? DBrecord.ItemName : StockItems.ItemName;
                DBrecord.Description = StockItems.Description == null || StockItems.Description == "" ? DBrecord.Description : StockItems.Description;
                DBrecord.Quantity = StockItems.Quantity;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMsg = e.ToString();
            }

        }

    }
}
