using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? HorometroMtto { get; set; }
        public string? HorasMtto { get; set; }
        public string? cliente { get; set; }
        public string? tipo { get; set; }
        public string? capacidad { get; set; }
        [DisplayName("Mástil")]
        public string? fases { get; set; }

        //Listas
        [NotMapped]
        public string DisplayInfoMntCrg => $"{NumeroEconomico} - {Marca} - {Modelo} - {NumeroSerie}";
    }
}
