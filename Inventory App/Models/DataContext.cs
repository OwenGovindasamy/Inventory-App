using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_App.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<StockItems> StockItems { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<StockMaterials> StockMaterials { get; set; }
    }
}
