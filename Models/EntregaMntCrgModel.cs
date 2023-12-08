using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class EntregaMntCrgModel
    {
        [Key]
        public int IdEntregaMntCrg { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int HorometroEntrega { get; set; }

        // Datos principales del inventario
        public MontacargasModel? Montacarga { get; set; }
        public int idMontacargas { get; set; }

        // Campos del formato de entrega
        public string? NivelAceiteMotor { get; set; }
        public string? NivelAnticongelante { get; set; }
        public string? NivelAceiteHidraulico { get; set; }
        public string? NivelLiquidoFrenos { get; set; }
        public string? TanqueGasSoportes { get; set; }
        public string? FrenoEstacionamiento { get; set; }
        public string? FugaSistemaGas { get; set; }
        public string? ElementoAire { get; set; }
        public string? DistanciaFrenado { get; set; }
        public string? CapacidadCarga { get; set; }
        public string? RespaldoCarga { get; set; }
        public string? Horquillas { get; set; }
        public string? Tablero { get; set; }
        public string? PinturaGeneral { get; set; }
        public string? CubiertaPiston { get; set; }
        public string? LlantasDireccion { get; set; }
        public string? LlantasTraccion { get; set; }
        public string? BateriaTerminales { get; set; }
        public string? LimpiezaGeneral { get; set; }
        public string? SistemaArranque { get; set; }
        public string? LucesTrabajo { get; set; }
        public string? LucesTraseras { get; set; }
        public string? Torreta { get; set; }
        public string? AlarmaReversa { get; set; }
        public string? Claxon { get; set; }
        public string? Extintor { get; set; }
        public string? Espejos { get; set; }
        public string? CinturonSeguridad { get; set; }
        public string? Asiento { get; set; }
        public string? FaroProximidad { get; set; }
        public string? Observaciones { get; set; }
        public string? Llave { get; set; }

        // Información de la recepción por parte del cliente
        public string? NombreCliente { get; set; }
        public string? EmpresaCliente { get; set; }
        public string? FirmaCliente{ get; set; }


        //Evidencias
        [NotMapped]
        public IFormFile? EvidenciaImagen1File { get; set; }

        public byte[]? EvidenciaImagen1 { get; set; }

        public string? EvidenciaImagen1Base64 { get; set; }
        [NotMapped]
        public IFormFile? EvidenciaImagen2File { get; set; }

        public byte[]? EvidenciaImagen2 { get; set; }

        public string? EvidenciaImagen2Base64 { get; set; }
    }
}
