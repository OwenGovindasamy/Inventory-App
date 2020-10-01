using Inventory_App.Models;

namespace Inventory_App.ViewModel
{
    public interface INewEntryVM
    {
        Materials Materials { get; set; }
        StockItems StockItems { get; set; }
    }
}