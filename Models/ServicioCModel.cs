using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class ServicioCModel
    {
        [Key]
        public int idServicioC { get; set; }

        [ForeignKey("Salidas")]
        [DisplayName("Almacen")]
        public int IdSalidaA { get; set; }
        public SalidaModel? Salidas { get; set; }

        [ForeignKey("Tareas")]
        [DisplayName("Tareas")]
        public int TareaId { get; set; }
        public Tarea? Tareas { get; set; }

        [DisplayName("Tareas seleccionadas")]
        public List<Tarea>? TareasSeleccionadas { get; set; }

        [DisplayName("Fecha Recepción")]
        public string? FechaR { get; set; }
        [DisplayName("Fecha Entrega")]
        public string? FechaE { get; set; }
        [DisplayName("Refacciones Remplazadas")]
        public string? Refacciones { get; set; }
        [DisplayName("Servicio a Domicilio")]
        public string? ServicioD { get; set; }
        [DisplayName("Status")]
        public string? Status { get; set; }
    }
}
