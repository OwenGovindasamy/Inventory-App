using Inventory_App.Models;
using Inventory_App.ViewModel;
using System.Collections.Generic;

namespace Inventory_App.Logic
{
    public interface IBusinessLogic
    {
        List<StockItems> GetStockItems();

        List<Materials> GetMaterial(int id);
        NewEntryVM CreateNewEntry(NewEntryVM vm);
        NewEntryVM UpdateEntry(int id, NewEntryVM vm);
    }
}