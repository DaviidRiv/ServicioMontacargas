using System.ComponentModel.DataAnnotations;

namespace ServicioMontacargas.Models
{
    public class MontacargasModel
    {
        [Key]
        public int IdMontacargas { get; set; }
        public string? NumeroSerie { get; set; }
        public string? NumeroEconomico { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Horometro { get; set; }
        public string? Status { get; set; }
        public string? Equipo { get; set; }
    }
}
