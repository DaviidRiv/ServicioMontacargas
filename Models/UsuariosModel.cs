using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServicioMontacargas.Models
{
    public class UsuariosModel
    {
        [Key]
        [DisplayName("ID")]
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        [DisplayName("Apellido Paterno")]
        public string? ApellidoP { get; set; }
        [DisplayName("Apellido Materno")]
        public string? ApellidoM { get; set; }
        public string? Password { get; set; }
        [DisplayName("Rol")]
        public string? rolUser { get; set; }
    }
}
