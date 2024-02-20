using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class ServicioCorrectivoModel
    {
        [Key]
        public int idServicioC { get; set; }

        [ForeignKey("Salidas")]
        [DisplayName("Almacen")]
        public int IdSalidaA { get; set; }
        public SalidaModel? Salidas { get; set; }

        [ForeignKey("Tareas")]
        [DisplayName("Tareas")]
        public int ComponenteId { get; set; }
        public ProcesosCorrectivoModel? Tareas { get; set; }

        public string? FechaR { get; set; }
        public string? FechaE { get; set; }
        public string? Refacciones { get; set; }
        public string? ServicioD { get; set; }
    }
}
