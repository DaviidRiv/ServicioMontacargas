using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class ChequeoDiarioModel 
    {
        [Key]
        public int IdChequeoDiario { get; set; }
        public string? Fecha { get; set; }
        [DisplayName("Horometro Actual")]
        public string? HorometroActual { get; set; }


        [ForeignKey("Montacargas")]
        [DisplayName("Montacargas")]
        public int? IdMontacargas { get; set; }
        public MontacargasModel? Montacargas { get; set; }

        //Chequeo
        [DisplayName("Nivel Aceite Motor")]
        public string? NivelAceiteMotor { get; set; }
        [DisplayName("Nivel Refrigerante")]
        public string? NivelRefrigerante { get; set; }
        [DisplayName("Fuga Lineas de Gas")]
        public string? FugaLineaGas { get; set; }
        [DisplayName("Func. Pedal de Freno")]
        public string? FuncPedestalFreno { get; set; }
        [DisplayName("Freno de Mano")]
        public string? FrenoMano { get; set; }
        [DisplayName("Fugas Aceite Hidraulico")]
        public string? FugasAceiteH { get; set; }
        [DisplayName("Func. de Direccion")]
        public string? FuncDireccion { get; set; }
        [DisplayName("Indicador Temperatura")]
        public string? IndicadoresTemp { get; set; }
        [DisplayName("Indicador Voltaje")]
        public string? IndicadoresVolt { get; set; }
        [DisplayName("Indicador Presion Aceite")]
        public string? IndicadoresPA { get; set; }
        [DisplayName("Tension de Cadenas")]
        public string? TensionCadenas { get; set; }
        [DisplayName("Llantas y Birlos")]
        public string? LlantasBirlos { get; set; }
        [DisplayName("Condiciones Generales")]
        public string? CondicionesGnrls { get; set; }
        [DisplayName("Palanca Avance y Reversa")]
        public string? PalancaAvanceReversa { get; set; }
        [DisplayName("Sistema Levante")]
        public string? SistemaLevante { get; set; }
        [DisplayName("Equipo Seguridad")]
        public string? EquipoSeguridad { get; set; }
        [DisplayName("Luces Trabajo")]
        public string? LucesTrabajo { get; set; }
        public string? Claxon { get; set; }
        public string? Torreta { get; set; }
        public string? Extintor { get; set; }
        [DisplayName("Cinturon Seguridad")]
        public string? CinturonSeguridad { get; set; }
        [DisplayName("Espejo Retrovisor")]
        public string? EspejoRetrovisor { get; set; }
        public string? Alarma { get; set; }
        [DisplayName("Plafon Stop")]
        public string? PlafonStop { get; set; }
        [DisplayName("Capacidad Carga")]
        public string? CapacidadCarga { get; set; }


        public string? Comentarios {  get; set; }
        [DisplayName("Nombre Operador")]
        public string? NombreOperador {  get; set; }
        [DisplayName("Firma Operador")]
        public string? FirmaOperador {  get; set; }
    }
}
