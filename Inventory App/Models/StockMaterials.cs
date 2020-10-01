using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_App.Models
{
    public class StockMaterials
    {
        public int Id { get; set; }
        public int StockItemId { get; set; }
        public int MaterialId { get; set; }
    }
}
