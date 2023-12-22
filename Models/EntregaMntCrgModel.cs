using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioMontacargas.Models
{
    public class EntregaMntCrgModel
    {
        [Key]
        [DisplayName("Folio")]
        public int IdEntregaMntCrg { get; set; }

        //Entrega
        [DisplayName("Fecha de Entrega")]
        [DataType(DataType.DateTime)]
        public DateTime FechaEntrega { get; set; }
        [DisplayName("Horometro de Entrega")]
        public int? HorometroEntrega { get; set; }

        //Recoleccion
        [DisplayName("Fecha de Recoleccion")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaRecoleccion { get; set; }        
        [DisplayName("Horometro de Recolección")]
        public int? HorometroRecoleccion { get; set; }

        // Datos principales del inventario
        public MontacargasModel? Montacarga { get; set; }
        [DisplayName("Montacargas")]
        public int idMontacargas { get; set; }

        // Campos del formato de entrega
        [DisplayName("Aceite del Motor")]
        public string? NivelAceiteMotor { get; set; }
        [DisplayName("Anticogelante")]
        public string? NivelAnticongelante { get; set; }
        [DisplayName("Aceite Hidraulico")]
        public string? NivelAceiteHidraulico { get; set; }
        [DisplayName("Liquido Frenos")]
        public string? NivelLiquidoFrenos { get; set; }
        [DisplayName("Aceite Diferencial")]
        public string? AceiteDiferencial { get; set; }
        [DisplayName("Tanque de gas y Soportes")]
        public string? TanqueGasSoportes { get; set; } 
        [DisplayName("Freno Estacionamiento")]
        public string? FrenoEstacionamiento { get; set; }
        [DisplayName("Fugas")]
        public string? FugaSistemaGas { get; set; }
        [DisplayName("Elemento de aire")]
        public string? ElementoAire { get; set; }
        [DisplayName("Distancia de frenado")]
        public string? DistanciaFrenado { get; set; }
        [DisplayName("Capacidad de carga")]
        public string? CapacidadCarga { get; set; }
        [DisplayName("Respaldo de carga")]
        public string? RespaldoCarga { get; set; }
        public string? Horquillas { get; set; }
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
        public string? Observaciones { get; set; }
        public string? Llave { get; set; }

        // Información de la recepción por parte del cliente
        [DisplayName("Nombre del Cliente")]
        public string? NombreCliente { get; set; }
        [DisplayName("Empresa del Cliente")]
        public string? EmpresaCliente { get; set; }
        [DisplayName("Firma del Cliente")]
        public string? FirmaCliente { get; set; }


        //Entrega
        [DisplayName("Nombre del Entregante")]
        public string? NombreJacsa { get; set; }

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

        //Evidencias Recoleccion
        [NotMapped]
        public IFormFile? EvidenciaRImagen1File { get; set; }
        [DisplayName("Evidencia Recolección 1")]
        public byte[]? EvidenciaRImagen1 { get; set; }
        [DisplayName("Evidencia Recolección 1")]
        public string? EvidenciaRImagen1Base64 { get; set; }
        [NotMapped]
        public IFormFile? EvidenciaRImagen2File { get; set; }
        [DisplayName("Evidencia Recolección 2")]
        public byte[]? EvidenciaRImagen2 { get; set; }
        [DisplayName("Evidencia Recolección 2")]
        public string? EvidenciaRImagen2Base64 { get; set; }

        //PDF
        [NotMapped]
        public string? MarcaMontacargas { get; set; }
        [NotMapped]
        public string? ModeloMontacargas { get; set; }
        [NotMapped]
        public string? NumeroSerieMontacargas { get; set; }
        [NotMapped]
        public string? NumeroEconomicoMontacargas { get; set; }
    }
}
