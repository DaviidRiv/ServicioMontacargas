using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServicioMontacargas.Models
{
    public class SalidaModel
    {

        [Key]
        public int IdSalidaA { get; set; }

        [ForeignKey("Clientes")]
        [DisplayName("Clientes")]
        public int? IdClientes { get; set; }
        public ClientesModel? Clientes { get; set; }

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

        [DisplayName("Firma de quien Recibió")]
        public string? FirmaRecibio { get; set; }
        [DisplayName("Nombre de quien Recibió")]
        public string? NombreRecibio { get; set; }
        [DisplayName("Firma de quien Entregó")]
        public string? FirmaEntrego { get; set; }
        [DisplayName("Nombre de quien Entregó")]
        public string? NombreEntrego { get; set; }

        public string FolioSalida => $"SC{(IdSalidaA < 10 ? $"0{IdSalidaA}" : IdSalidaA.ToString())}-{Montacargas?.NumeroEconomico}-{Fecha?.ToString()}";

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

        public int SalidaModelIdSalidaA { get; set; }
        public SalidaModel? SalidaModel { get; set; }
    }

    public class SelectedProductModel
    {
        public string? Product { get; set; }
        public int Quantity { get; set; }
        public int idAlmacen { get; set; }
    }

}
