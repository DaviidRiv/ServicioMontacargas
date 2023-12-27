using System.ComponentModel.DataAnnotations;

namespace ServicioMontacargas.Models
{
    public class UsuariosModel
    {
        [Key]
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoP { get; set; }
        public string? ApellidoM { get; set; }
        public string? Password { get; set; }
        public string? rolUser { get; set; }
    }
}
