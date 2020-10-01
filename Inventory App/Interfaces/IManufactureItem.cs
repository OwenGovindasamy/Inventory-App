using Inventory_App.ViewModel;
using System.Collections.Generic;

namespace Inventory_App.Logic
{
    public interface IManufactureItem
    {
        List<string> Manufacture(int id, ManufactureVM vM);
    }
}