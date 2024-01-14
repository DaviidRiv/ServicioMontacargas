using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class ClientesModel
    {
        [Key]
        public int IdClientes { get; set; }
        public string? Nombre { get; set; }
        [DisplayName("Fecha de Registro")]
        public string? FechaRegistro { get; set; }
        [DisplayName("Ubicación")]
        public string? Ubicacion { get; set; }

        //Listas
        [NotMapped]
        public string DisplayInfoCl => $"{IdClientes} - {Nombre}";
    }
}
