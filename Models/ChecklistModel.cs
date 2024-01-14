using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class ChecklistModel
    {
        [Key]
        [DisplayName("Folio")]
        public int IdChecklist { get; set; }
        [DisplayName("Nombre del Operador")]
        public string? nombreOperador { get; set; }

        [ForeignKey("Clientes")]
        [DisplayName("Empresa")]
        public int IdClientes { get; set; }
        public ClientesModel? Clientes { get; set; }
        [DisplayName("Turno")]
        public string? turno { get; set; }
        [ForeignKey("Montacargas")]
        [DisplayName("Montacargas")]
        public int IdMontacargas { get; set; }
        public MontacargasModel? Montacargas { get; set; }

        [DisplayName("Horometro")]
        public string? horometro { get; set; }

        //Lista Checklist
        [DisplayName("Aceite del Motor")]
        public string? NivelAceiteMotor { get; set; }
        [DisplayName("Anticogelante")]
        public string? NivelAnticongelante { get; set; }
        [DisplayName("Aceite Hidraulico")]
        public string? NivelAceiteHidraulico { get; set; }
        [DisplayName("Liquido Frenos")]
        public string? NivelLiquidoFrenos { get; set; }
        [DisplayName("Banda Ventilador")]
        public string? BandaVentilador { get; set; }
        [DisplayName("Tanque de gas y Soportes")]
        public string? TanqueGasSoportes { get; set; }
        [DisplayName("Freno Estacionamiento")]
        public string? FrenoEstacionamiento { get; set; }
        [DisplayName("Fugas")]
        public string? FugaSistemaGas { get; set; }
        [DisplayName("Distancia de frenado")]
        public string? DistanciaFrenado { get; set; }
        [DisplayName("Respaldo de carga")]
        public string? RespaldoCarga { get; set; }
        public string? Horquillas { get; set; }
        public string? Golpes { get; set; }
        public string? Tablero { get; set; }
        [DisplayName("Pintura General")]
        public string? PinturaGeneral { get; set; }
        [DisplayName("Cubierta y Piston")]
        public string? CubiertaPiston { get; set; }
        [DisplayName("Llantas de direccion")]
        public string? LlantasDireccion { get; set; }
        [DisplayName("Llantas de traccion")]
        public string? LlantasTraccion { get; set; }
        [DisplayName("Bateria y terminales")]
        public string? BateriaTerminales { get; set; }
        [DisplayName("Limpieza General")]
        public string? LimpiezaGeneral { get; set; }
        public string? Radiador { get; set; }
        [DisplayName("Sistema de arranque")]
        public string? SistemaArranque { get; set; }
        [DisplayName("Luces de trabajo")]
        public string? LucesTrabajo { get; set; }
        [DisplayName("Luces traseras")]
        public string? LucesTraseras { get; set; }
        public string? Torreta { get; set; }
        [DisplayName("Alarma de Reversa")]
        public string? AlarmaReversa { get; set; }
        public string? Claxon { get; set; }
        public string? Extintor { get; set; }
        public string? Espejos { get; set; }
        [DisplayName("Cinturon de Seguridad")]
        public string? CinturonSeguridad { get; set; }
        public string? Asiento { get; set; }
        [DisplayName("Faro de proximidad")]
        public string? FaroProximidad { get; set; }
        [DisplayName("Ruidos raros")]
        public string? Ruidos { get; set; }
        public string? Observaciones { get; set; }
        [DisplayName("Firma")]
        public string? Firma { get; set; }

        //Evidencias Entrega
        [NotMapped]
        public IFormFile? EvidenciaImagen1File { get; set; }
        [DisplayName("Evidencia 1")]
        public byte[]? EvidenciaImagen1 { get; set; }
        [DisplayName("Evidencia 1")]
        public string? EvidenciaImagen1Base64 { get; set; }
        [NotMapped]
        public IFormFile? EvidenciaImagen2File { get; set; }
        [DisplayName("Evidencia 2")]
        public byte[]? EvidenciaImagen2 { get; set; }
        [DisplayName("Evidencia 2")]
        public string? EvidenciaImagen2Base64 { get; set; }        

    }
}
