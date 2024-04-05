using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ServicioMontacargas.Models
{
    public class ChecklistViewModel
    {
        public int IdChecklist { get; set; }
        public string? nombreOperador { get; set; }
        public string? nombreJacsa { get; set; }
        public int IdClientes { get; set; }
        public ClientesModel? Clientes { get; set; }
        public string? turno { get; set; }
        public int IdMontacargas { get; set; }
        public MontacargasModel? Montacargas { get; set; }
        public string? NumeroEconomicoMontacargas { get; set; }
        public string? horometro { get; set; }
        public string? fecha { get; set; }

        //Lista Checklist
        public string? NivelAceiteMotor { get; set; }
        public string? NivelAnticongelante { get; set; }
        public string? NivelAceiteHidraulico { get; set; }
        public string? NivelLiquidoFrenos { get; set; }
        public string? BandaVentilador { get; set; }
        public string? TanqueGasSoportes { get; set; }
        public string? FrenoEstacionamiento { get; set; }
        public string? FugaSistemaGas { get; set; }
        public string? DistanciaFrenado { get; set; }
        public string? RespaldoCarga { get; set; }
        public string? Horquillas { get; set; }
        public string? Golpes { get; set; }
        public string? Tablero { get; set; }
        public string? PinturaGeneral { get; set; }
        public string? CubiertaPiston { get; set; }
        public string? LlantasDireccion { get; set; }
        public string? LlantasTraccion { get; set; }
        public string? BateriaTerminales { get; set; }
        public string? LimpiezaGeneral { get; set; }
        public string? Radiador { get; set; }
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
        public string? Ruidos { get; set; }
        public string? Llave { get; set; }
        public string? Observaciones { get; set; }
    }
}
