using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class ServicioPModel
    {
        [Key]
        public int IdServicioP { get; set; }

        [ForeignKey("Clientes")]
        [DisplayName("Clientes")]
        public int IdClientes { get; set; }
        public ClientesModel? Clientes { get; set; }

        [ForeignKey("Montacargas")]
        [DisplayName("Montacargas")]
        public int IdMontacargas { get; set; }
        public MontacargasModel? Montacargas { get; set; }
        public string? Fecha { get; set; }

        //Motor
        [DisplayName("Aceite del Motor")]
        public string? NivelAceiteMotor { get; set; }
        [DisplayName("Filtro Aceite Motor")]
        public string? FiltroAceiteMotor { get; set; }
        [DisplayName("Elementos de Aire")]
        public string? ElementosAire { get; set; }
        [DisplayName("Bujías")]
        public string? VálvulasPCV { get; set; }
        [DisplayName("Limpieza")]
        public string? Limpieza { get; set; }
        [DisplayName("Fugas")]
        public string? Fugas { get; set; }
        [DisplayName("Capuchón Bujía")]
        public string? CapuchoBujia { get; set; }
        [DisplayName("Sello Capuchón Bujía")]
        public string? SelloCapBujia { get; set; }
        [DisplayName("Tiempo")]
        public string? Tiempo { get; set; }

        //Sistema Carburacion
        [DisplayName("Vaporizador")]
        public string? Vaporizador { get; set; }
        [DisplayName("Válvula de Vacío")]
        public string? ValvulaVacio { get; set; }
        [DisplayName("Mezclador")]
        public string? Mezclador { get; set; }
        [DisplayName("Repuesto Vaporizador")]
        public string? RepuestoVaporizador { get; set; }
        [DisplayName("Repuesto Mezclador")]
        public string? RepuestoMezclador { get; set; }
        [DisplayName("Repuesto Válcula de Vacío")]
        public string? RespuestoValVacio { get; set; }
        [DisplayName("Selenoide")]
        public string? Selenoide { get; set; }
        [DisplayName("Filtro")]
        public string? Filtro { get; set; }
        [DisplayName("Tanque Gas y Soporte")]
        public string? TanqueGas { get; set; }
        [DisplayName("Mangueras y Conexiones")]
        public string? MangueConex { get; set; }
        [DisplayName("Fugas en Sistema")]
        public string? FugasSistema { get; set; }

        //Sistema Electrico
        [DisplayName("Alternador")]
        public string? Alternador { get; set; }
        [DisplayName("Batería y Terminales")]
        public string? BateriaTermi { get; set; }
        [DisplayName("Indicadores")]
        public string? Indicadores { get; set; }

        //Sistema Enfriamiento
        [DisplayName("Anticongelante")]
        public string? Anticongelante { get; set; }
        [DisplayName("Banda Ventilador")]
        public string? BandaV { get; set; }
        [DisplayName("Manguera Radiador Sup")]
        public string? MangueraRS { get; set; }
        [DisplayName("Manguera Radiador Inf")]
        public string? MangueraRI { get; set; }
        [DisplayName("Radiador")]
        public string? Radiador { get; set; }
        [DisplayName("Ventilador")]
        public string? Ventilador { get; set; }

        //Ignicion
        [DisplayName("Motor de Arranque")]
        public string? MotorA { get; set; }
        [DisplayName("Bobina")]
        public string? Bobina { get; set; }
        [DisplayName("Cables Bujías")]
        public string? CablesB { get; set; }
        [DisplayName("Tapa Distribuidor")]
        public string? TapaD { get; set; }
        [DisplayName("Rotor Distribuidor")]
        public string? RotorD { get; set; }
        [DisplayName("Pastilla Carburador")]
        public string? PastillaC { get; set; }
        [DisplayName("Distribuidor")]
        public string? Distribuidor { get; set; }
        [DisplayName("Switch Encendido")]
        public string? SwitchE { get; set; }

        //Transmision
        [DisplayName("Estado y Nivel Aceite")]
        public string? EdoNivelA { get; set; }
        [DisplayName("Filtro de Trasnmisión")]
        public string? FiltroT { get; set; }
        [DisplayName("Fugas de Aceite")]
        public string? FugasA { get; set; }
        [DisplayName("Mangueras")]
        public string? Mangueras { get; set; }
        [DisplayName("Cable Pedal Acercamiento")]
        public string? CablePedal { get; set; }

        //Direccion
        [DisplayName("Mangos Dirección")]
        public string? MangosDire { get; set; }
        [DisplayName("Eslabón")]
        public string? Eslabon { get; set; }
        [DisplayName("Pernos de Eslabón")]
        public string? PernosEslabon { get; set; }
        [DisplayName("Llantas")]
        public string? Llantas { get; set; }
        [DisplayName("Birlos y Turcas")]
        public string? BirlosTurcas { get; set; }

        //Sistema Hidraulico
        [DisplayName("Estado y Nivel Aceite")]
        public string? EdoyNivelA { get; set; }
        [DisplayName("Fugas")]
        public string? FugasSH { get; set; }

        //Sistemas de Frenos
        [DisplayName("Nivel Liquido Frenos")]
        public string? NivelLiquidoF { get; set; }
        [DisplayName("Cilindro Maestro")]
        public string? CilindroM { get; set; }
        [DisplayName("Ajuste")]
        public string? Ajuste { get; set; }
        [DisplayName("Purgar")]
        public string? Purgar { get; set; }
        [DisplayName("Fugas")]
        public string? FugasF { get; set; }
        [DisplayName("Freno de Estacionamiento")]
        public string? FrenoEst { get; set; }

        //Tren Motriz
        [DisplayName("Aceite Diferencial")]
        public string? AceiteDif { get; set; }
        [DisplayName("Crucetas")]
        public string? Crucetas { get; set; }
        [DisplayName("Llantas")]
        public string? LlantasTM { get; set; }

        //Equipo Seguridad
        [DisplayName("Luces de Trabajo")]
        public string? LucesTrab { get; set; }
        [DisplayName("Plafón Assy Combo")]
        public string? PlafonAssy { get; set; }
        [DisplayName("Torreta")]
        public string? Torreta { get; set; }
        [DisplayName("Alarma Reversa")]
        public string? AlarmaReversa { get; set; }
        [DisplayName("Claxon")]
        public string? Claxon { get; set; }
        [DisplayName("Extintor")]
        public string? Extintor { get; set; }
        [DisplayName("Espejos")]
        public string? Espejos { get; set; }
        [DisplayName("Cinturon de Seguridad")]
        public string? CinturonS { get; set; }

        //Generales
        [DisplayName("Respaldo de Carga")]
        public string? RespaldoC { get; set; }
        [DisplayName("Horquillas")]
        public string? Horquillas { get; set; }
        [DisplayName("Asiento")]
        public string? Asiento { get; set; }
        [DisplayName("Golpes")]
        public string? Golpes { get; set; }
        [DisplayName("Tablero")]
        public string? Tablero { get; set; }
        [DisplayName("Pintura")]
        public string? Pintura { get; set; }
        [DisplayName("Cubierta y Pistón")]
        public string? CubiertaP { get; set; }
        [DisplayName("Servicio Lavado y Engrasado")]
        public string? ServicioLyE { get; set; }

        //Firmas
        [DisplayName("Firma JACSA")]
        public string? FirmaJ { get; set; }
        [DisplayName("Firma Cliente")]
        public string? FirmaC { get; set; }

        //FolioSP
        public string FolioSP => $"SP{(IdServicioP < 10 ? $"0{IdServicioP}" : IdServicioP.ToString())}-{Montacargas?.NumeroEconomico}-{Fecha?.ToString()}";

        //Almacen
        [DisplayName("Cantidad")]
        public string? Cantidad { get; set; }
        [DisplayName("No. de Parte")]
        public string? NoParte { get; set; }
        [DisplayName("Descripción")]
        public string? Descripcion { get; set; }
        public List<Producto>? Productos { get; set; }
        public class Producto
        {
            [Key]
            public int idProductoSP { get; set; }
            [DisplayName("Cantidad")]
            public int Cantidad { get; set; }

            [DisplayName("No. de Parte")]
            public string? NoParte { get; set; }

            [DisplayName("Descripción")]
            public string? Descripcion { get; set; }            
        }

        [DisplayName("Comentarios")]
        public string? Comentarios { get; set; }
    }
}
