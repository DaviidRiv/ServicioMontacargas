using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServicioMontacargas.Models
{
    public class RevisionCamionModel
    {
        [Key]
        public int IdRevisionCamion { get; set; }

        public string? NivelCombustible { get; set; }
        public string? Fecha { get; set; }
        public string? Kilometraje { get; set; }

        [ForeignKey("Montacargas")]
        [DisplayName("Montacargas")]
        public int IdMontacargas { get; set; }
        public MontacargasModel? Montacargas { get; set; }

        public string? Comentarios { get; set; }

        //Campos Inventario
        [DisplayName("Aceite de Motor")]
        public string? NivelAceiteMotor { get; set; }
        [DisplayName("Aceite de Transmision")]
        public string? NivelAceiteTrans { get; set; }
        [DisplayName("Aceite de Dirección")]
        public string? NivelAceiteDirec { get; set; }
        [DisplayName("Aceite Hidraulico")]
        public string? NivelAceiteHidrau { get; set; }
        [DisplayName("Refrigerante Motor")]
        public string? RefrigeranteMotor { get; set; }
        [DisplayName("Liquido de Frenos")]
        public string? LiquidoFrenos { get; set; }
        [DisplayName("Radiador")]
        public string? Radiador { get; set; }
        [DisplayName("Indicador de Combustible")]
        public string? IndicadorCombus { get; set; }
        [DisplayName("Indicador de Temperatura")]
        public string? IndicadorTemp { get; set; }
        [DisplayName("Indicador de Presion de Aceite")]
        public string? IndicadorPresionA { get; set; }
        [DisplayName("Baterias y Terminales")]
        public string? BateriayTerminales { get; set; }
        [DisplayName("Direccion")]
        public string? Direccion { get; set; }
        [DisplayName("Frenos (Distancia Frenado)")]
        public string? Frenos { get; set; }
        [DisplayName("Frenos Estacionamiento")]
        public string? FrenosEstac { get; set; }
        [DisplayName("Lineas de Aire")]
        public string? LineasAire { get; set; }
        [DisplayName("Suspension Delantera")]
        public string? SuspensionD { get; set; }
        [DisplayName("Muelles")]
        public string? Muelles { get; set; }
        [DisplayName("Pintura y Carroceria")]
        public string? PinturayC { get; set; }
        [DisplayName("Orden y Limpieza Gen")]
        public string? OrdenyLG { get; set; }
        [DisplayName("Llantas Delanteras")]
        public string? LlantasDelanteras { get; set; }

        //2do Split
        [DisplayName("Llantas Traseras LD")]
        public string? LlantasTraserasLD { get; set; }
        [DisplayName("Llantas Trasera LI")]
        public string? LlantasTraserasLI { get; set; }
        [DisplayName("Luces Delanteras Baja")]
        public string? LucesDelanterasB { get; set; }
        [DisplayName("Luces Delanteras Alta")]
        public string? LucesDelanterasA { get; set; }
        [DisplayName("Luces Traseras")]
        public string? LucesTraseras{ get; set; }
        [DisplayName("Luces de Freno")]
        public string? LucesFreno { get; set; }
        [DisplayName("Luces Intermitentes")]
        public string? LucesIntermitentes { get; set; }
        [DisplayName("Luces Direccionales")]
        public string? LucesDireccionales { get; set; }
        [DisplayName("Claxon")]
        public string? Claxon { get; set; }
        [DisplayName("Alarma de Reversa")]
        public string? AlarmaReversa { get; set; }
        [DisplayName("Limpiaparabrisas")]
        public string? Limpiaparabrisas { get; set; }
        [DisplayName("Espejos Retrovisores")]
        public string? EspejosRetrovisores { get; set; }
        [DisplayName("Parabrisas o Vidrio Delantero")]
        public string? ParabrisasVD { get; set; }
        [DisplayName("Medallon o Vidrio Trasero")]
        public string? MedallonVT { get; set; }
        [DisplayName("Vidrio Lateral Derecho")]
        public string? VidrioLD { get; set; }
        [DisplayName("Vidrio Laterl Izquierdo")]
        public string? VidrioLI { get; set; }
        [DisplayName("Aleron Derecho")]
        public string? AleronD { get; set; }
        [DisplayName("Aleron Izquierdo")]
        public string? AleronI { get; set; }
        [DisplayName("Extintor")]
        public string? Extintor { get; set; }
        [DisplayName("Tapon de Combustible")]
        public string? TaponC { get; set; }
        [DisplayName("Nombre Operador")]
        public string? NombreOperador { get; set; }
        [DisplayName("Firma Operador")]
        public string? FirmaOperador { get; set; }
        [DisplayName("Nombre Inspector")]
        public string? NombreInspector { get; set; }
        [DisplayName("Firma Inspector")]
        public string? FirmaInspector { get; set; }
    }
}
