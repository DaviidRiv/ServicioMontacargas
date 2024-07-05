using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
namespace ServicioMontacargas.Models
{
    public class EntradaSalidaModel
    {
        [Key]
        public int IdEntradaSalida { get; set; }
        public string? Personal { get; set; }
        [DisplayName("Fecha de Entrada")]
        public string? FechaEntrada { get; set; }
        [DisplayName("Fecha de Salida")]
        public string? FechaSalida { get; set; }
        public string? Tipo { get; set; }
        [DisplayName("Modificado por el Usuario")]
        public int? IdUser { get; set; }

        public double? LatitudE { get; set; }
        public double? LongitudE { get; set; }

        public double? LatitudS { get; set; }
        public double? LongitudS { get; set; }

    }
    public class LocationData
    {
        public int? IdUser { get; set; }
        public string UbicacionE { get; set; }
    }
}
