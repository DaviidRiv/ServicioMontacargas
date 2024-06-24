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
        public DbSet<ServicioMontacargas.Models.ProcesosCorrectivoModel>? ProcesosCorrectivoModel { get; set; }
        public DbSet<ServicioMontacargas.Models.Tarea>? Tarea { get; set; }        
        public DbSet<ServicioMontacargas.Models.ServicioPModel>? ServicioPModel { get; set; }
        public DbSet<ServicioMontacargas.Models.Producto>? Producto { get; set; }
        public DbSet<ServicioMontacargas.Models.ServicioCoModel>? ServicioCoModel { get; set; }
        public DbSet<ServicioMontacargas.Models.ProductoSCo>? ProductoSCo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServicioMontacargas.Models.SalidaModel>()
                .HasMany(sm => sm.SalidaItems)
                .WithOne(si => si.SalidaModel)
                .HasForeignKey(si => si.SalidaModelIdSalidaA)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Componente)
                .WithMany(pc => pc.Tareas)
                .HasForeignKey(t => t.ComponenteId)
                .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.ServicioCoModel)
                .WithMany(sc => sc.TareasSeleccionadas)
                .HasForeignKey(t => t.ServicioCoModelIdServicioCo)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.Cascade if you want cascade delete
        }

        public async Task ActualizarHorasMtto()
        {
            await Database.ExecuteSqlRawAsync("EXEC ActualizarHorasMtto");
        }

        public DbSet<ServicioMontacargas.Models.EntradaSalidaModel>? EntradaSalidaModel { get; set; }

        public DbSet<ServicioMontacargas.Models.RevisionCamionModel>? RevisionCamionModel { get; set; }
    }
}
