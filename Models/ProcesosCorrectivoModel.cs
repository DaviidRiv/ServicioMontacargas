using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{

    public class ProcesosCorrectivoModel
    {
        public ProcesosCorrectivoModel()
        {
            Tareas = new List<Tarea>(); 
        }
        [Key]
        public int ComponenteId { get; set; }
        [DisplayName("Componente")]
        public string? Nombre { get; set; }
        public List<Tarea>? Tareas { get; set; }
    }

    public class Tarea
    {
        [Key]
        public int TareaId { get; set; }
        public string? Descripcion { get; set; }
        public int ComponenteId { get; set; }
        [ForeignKey("ComponenteId")]
        public ProcesosCorrectivoModel? Componente { get; set; }

    }
}
