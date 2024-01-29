using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class AlmacenModel
    {
        [Key]
        public int IdAlmacen { get; set; }
        public string? Producto { get; set; }
        public string? Nombre { get; set; }
        [DisplayName("Unidad de Medida")]
        public string? Medida { get; set; }

    }
}
