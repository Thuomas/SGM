using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGM.Models;

namespace SGM.Data
{
    public class StockContext : DbContext
    {
        public StockContext (DbContextOptions<StockContext> options)
            : base(options)
        {
        }

        public DbSet<Modelo> Modelo { get; set; } = default!;
        public DbSet<SGM.Models.Trabajo> Trabajo { get; set; } = default!;
        public DbSet<SGM.Models.Observacion> Observacion { get; set; } = default!;
        public DbSet<SGM.Models.ControlEquipo> ControlEquipo { get; set; } = default!;
        public DbSet<SGM.Models.InsumoCritico> InsumoCritico { get; set; } = default!;
        public DbSet<SGM.Models.Produccion> Produccion { get; set; } = default!;
        public DbSet<SGM.Models.Entrega> Entrega { get; set; } = default!;
    }
}
