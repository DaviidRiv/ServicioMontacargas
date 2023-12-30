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
        public ServicioMontacargasContext(DbContextOptions<ServicioMontacargasContext> options)
            : base(options)
        {
        }

        public DbSet<ServicioMontacargas.Models.MontacargasModel> MontacargasModel { get; set; } = default!;
        public DbSet<ServicioMontacargas.Models.EntregaMntCrgModel>? EntregaMntCrgModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones u otras configuraciones de tu modelo

            modelBuilder.Entity<EntregaMntCrgModel>()
                .HasOne(e => e.Montacarga)
                .WithMany()
                .HasForeignKey(e => e.idMontacargas); // Asegúrate de que esta es la clave correcta
        }

        public DbSet<ServicioMontacargas.Models.UsuariosModel>? UsuariosModel { get; set; }
    }
}
