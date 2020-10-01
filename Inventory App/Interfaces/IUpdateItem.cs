using Inventory_App.Models;
using Inventory_App.ViewModel;

namespace Inventory_App.Logic
{
    public interface IUpdateItem
    {
        void UpdateMaterial(MaterialVM Materials);
        void UpdateStockItem(StockItems StockItems);
        void UpdateStockItemVM(StockItemVM StockItems);
    }
}