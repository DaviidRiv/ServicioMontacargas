using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServicioMontacargas.Models;

namespace ServicioMontacargas.Data
{
    public class ServicioMontacargasContext : DbContext
    {
        public ServicioMontacargasContext (DbContextOptions<ServicioMontacargasContext> options)
            : base(options)
        {
        }

        public DbSet<ServicioMontacargas.Models.MontacargasModel> MontacargasModel { get; set; } = default!;
    }
}
