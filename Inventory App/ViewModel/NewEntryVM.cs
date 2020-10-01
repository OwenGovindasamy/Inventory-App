using Inventory_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_App.ViewModel
{
    public class NewEntryVM
    {
        public Materials Materials { get; set; }
        public StockItems StockItems { get; set; }
    }
}
