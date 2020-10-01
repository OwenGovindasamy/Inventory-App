using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_App.ViewModel
{
    public class StockItemVM
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public long Quantity { get; set; }
    }
}
