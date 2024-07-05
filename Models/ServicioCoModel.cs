using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class ServicioCoModel
    {
        [Key]
        public int IdServicioCo { get; set; }

        [ForeignKey("Clientes")]
        [DisplayName("Clientes")]
        public int IdClientes { get; set; }
        public ClientesModel? Clientes { get; set; }

        [DisplayName("Causa de Falla")]
        public string? CausaFalla { get; set; }

        public List<ProductoSCo>? Productos { get; set; }

        [ForeignKey("Montacargas")]
        [DisplayName("Montacargas")]
        public int IdMontacargas { get; set; }
        public MontacargasModel? Montacargas { get; set; }
        [DisplayName("Horometro")]
        public int? Horometro { get; set; }

        [DisplayName("Fecha Registro")]
        public string? FechaReg { get; set; }
        [DisplayName("Fecha Recepción")]
        public string? FechaR { get; set; }
        [DisplayName("Fecha Entrega")]
        public string? FechaE { get; set; }
        [DisplayName("¿Entrega Refacciones Remplazadas?")]
        public string? Refacciones { get; set; }
        [DisplayName("¿Servicio a Domicilio del Cliente?")]
        public string? ServicioD { get; set; }

        //Firmas
        [DisplayName("Firma Mecánico")]
        public string? FirmaJ { get; set; }
        [DisplayName("Firma Cliente")]
        public string? FirmaC { get; set; }

        //Nombres
        [DisplayName("Nombre Mecánico")]
        public string? NombreJ { get; set; }
        [DisplayName("Nombre Cliente")]
        public string? NombreC { get; set; }

        [DisplayName("Status")]
        public string? Status { get; set; }
        public string FolioSC => $"SC{(IdServicioCo < 10 ? $"0{IdServicioCo}" : IdServicioCo.ToString())}-{Montacargas?.NumeroEconomico}-{FechaReg?.ToString()}";

        // Esta lista se relaciona con ServicioTarea
        public List<ServicioTarea> ServicioTareas { get; set; } = new List<ServicioTarea>();

        [NotMapped]
        public List<Tarea> TareasSeleccionadas => ServicioTareas.Select(st => st.Tarea).ToList();
        public int? TareaId { get; set; }

    }

    public class ProductoSCo
    {
        [Key]
        public int idProductoSP { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }

        [DisplayName("No. de Parte")]
        public string? NoParte { get; set; }

        [DisplayName("Descripción")]
        public string? Descripcion { get; set; }
        public int ServicioCoModelIdServicioCo { get; set; }
        public ServicioCoModel? ServicioCoModel { get; set; }
    }
    public class ServicioTarea
    {
        public int ServicioCoModelId { get; set; }
        public ServicioCoModel? ServicioCoModel { get; set; }

        public int TareaId { get; set; }
        public Tarea? Tarea { get; set; }
    }
}

