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

        public DbSet<ServicioMontacargas.Models.UsuariosModel>? UsuariosModel { get; set; }

        public DbSet<ServicioMontacargas.Models.ClientesModel>? ClientesModel { get; set; }

        public DbSet<ServicioMontacargas.Models.ChecklistModel>? ChecklistModel { get; set; }

        public DbSet<ServicioMontacargas.Models.AlmacenModel>? AlmacenModel { get; set; }

        public DbSet<ServicioMontacargas.Models.SalidaModel>? SalidaModel { get; set; }
        public DbSet<ServicioMontacargas.Models.SalidaItem>? SalidaItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicioMontacargas.Models.SalidaModel>()
                .HasMany(sm => sm.SalidaItems)
                .WithOne(si => si.SalidaModel)
                .HasForeignKey(si => si.SalidaModelIdSalidaA)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<ServicioMontacargas.Models.ProcesosCorrectivoModel>? ProcesosCorrectivoModel { get; set; }
        public DbSet<ServicioMontacargas.Models.Tarea>? Tarea { get; set; }
        public DbSet<ServicioMontacargas.Models.ServicioPModel>? ServicioPModel { get; set; }
        public DbSet<ServicioMontacargas.Models.Producto>? Producto { get; set; }
        public DbSet<ServicioMontacargas.Models.ServicioCoModel>? ServicioCoModel { get; set; }
        public DbSet<ServicioMontacargas.Models.ProductoSCo>? ProductoSCo { get; set; }

    }
}
