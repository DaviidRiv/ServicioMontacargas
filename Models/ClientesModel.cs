using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServicioMontacargas.Models
{
    public class ClientesModel
    {
        [Key]
        public int IdClientes { get; set; }
        public string? Nombre { get; set; }
        public string? FechaRegistro { get; set; }
        public string? Ubicacion { get; set; }

    }
}
