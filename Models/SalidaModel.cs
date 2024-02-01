using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServicioMontacargas.Models
{
    public class SalidaModel
    {

        [Key]
        public int IdSalidaA { get; set; }
        public string? Cliente { get; set; }
        public string? Fecha { get; set; }

        [ForeignKey("Montacargas")]
        [DisplayName("Montacargas")]
        public int? IdMontacargas { get; set; }
        public MontacargasModel? Montacargas { get; set; }

        [ForeignKey("Almacen")]
        [DisplayName("Almacen")]
        public int? IdAlmacen { get; set; }
        public AlmacenModel? Almacen { get; set; }

        public List<SalidaItem> SalidaItems { get; set; } = new List<SalidaItem>();

        public string? FirmaRecibio { get; set; }
        public string? FirmaEntrego { get; set; }

        public string FolioSalida => $"SC{IdSalidaA}-{Montacargas?.NumeroEconomico}-{Fecha?.ToString()}";
    }

    public class SalidaItem
    {
        [Key]
        public int IdSalidaItem { get; set; }

        [ForeignKey("Almacen")]
        public int IdAlmacen { get; set; }
        public AlmacenModel? Almacen { get; set; }
        public int Cantidad { get; set; }
        public int IdSalidaA { get; set; }
    }

    public class SelectedProductModel
    {
        public string? Product { get; set; }
        public int Quantity { get; set; }
        public int idAlmacen { get; set; }
    }

}
