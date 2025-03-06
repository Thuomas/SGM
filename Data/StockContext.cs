using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Models;

namespace SGM.Data
{
    public class StockContext : DbContext
    {
        public StockContext (DbContextOptions<StockContext> options)
            : base(options)
        {
        }

        public DbSet<Modelo> Modelo { get; set; } = default!;
        public DbSet<Stock.Models.Trabajo> Trabajo { get; set; } = default!;
    }
}
