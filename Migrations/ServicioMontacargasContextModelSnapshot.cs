﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicioMontacargas.Data;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    [DbContext(typeof(ServicioMontacargasContext))]
    partial class ServicioMontacargasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServicioMontacargas.Models.AlmacenModel", b =>
                {
                    b.Property<int>("IdAlmacen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlmacen"), 1L, 1);

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAlmacen");

                    b.ToTable("AlmacenModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ChecklistModel", b =>
                {
                    b.Property<int>("IdChecklist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdChecklist"), 1L, 1);

                    b.Property<string>("AlarmaReversa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Asiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BandaVentilador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BateriaTerminales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CinturonSeguridad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Claxon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CubiertaPiston")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistanciaFrenado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Espejos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EvidenciaImagen1")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EvidenciaImagen1Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EvidenciaImagen2")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EvidenciaImagen2Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extintor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaroProximidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenoEstacionamiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FugaSistemaGas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Golpes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horquillas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdClientes")
                        .HasColumnType("int");

                    b.Property<int>("IdMontacargas")
                        .HasColumnType("int");

                    b.Property<string>("LimpiezaGeneral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LlantasDireccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LlantasTraccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Llave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LucesTrabajo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LucesTraseras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelAceiteHidraulico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelAceiteMotor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelAnticongelante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelLiquidoFrenos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroEconomicoMontacargas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinturaGeneral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Radiador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespaldoCarga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SistemaArranque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tablero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TanqueGasSoportes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Torreta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("horometro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreJacsa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreOperador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdChecklist");

                    b.HasIndex("IdClientes");

                    b.HasIndex("IdMontacargas");

                    b.ToTable("ChecklistModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ClientesModel", b =>
                {
                    b.Property<int>("IdClientes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClientes"), 1L, 1);

                    b.Property<string>("FechaRegistro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClientes");

                    b.ToTable("ClientesModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.EntregaMntCrgModel", b =>
                {
                    b.Property<int>("IdEntregaMntCrg")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEntregaMntCrg"), 1L, 1);

                    b.Property<string>("AceiteDiferencial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlarmaReversa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Asiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BateriaTerminales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CapacidadCarga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CinturonSeguridad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Claxon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CubiertaPiston")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistanciaFrenado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElementoAire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpresaCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Espejos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EvidenciaImagen1")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EvidenciaImagen1Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EvidenciaImagen2")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EvidenciaImagen2Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EvidenciaRImagen1")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EvidenciaRImagen1Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EvidenciaRImagen2")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EvidenciaRImagen2Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extintor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaroProximidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRecoleccion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirmaCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenoEstacionamiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FugaSistemaGas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HorometroEntrega")
                        .HasColumnType("int");

                    b.Property<int?>("HorometroRecoleccion")
                        .HasColumnType("int");

                    b.Property<string>("Horquillas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdMontacargas")
                        .HasColumnType("int");

                    b.Property<string>("LimpiezaGeneral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LlantasDireccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LlantasTraccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Llave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LucesTrabajo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LucesTraseras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelAceiteHidraulico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelAceiteMotor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelAnticongelante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelLiquidoFrenos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreJacsa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinturaGeneral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespaldoCarga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SistemaArranque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tablero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TanqueGasSoportes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Torreta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEntregaMntCrg");

                    b.HasIndex("IdMontacargas");

                    b.ToTable("EntregaMntCrgModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.MontacargasModel", b =>
                {
                    b.Property<int>("IdMontacargas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMontacargas"), 1L, 1);

                    b.Property<string>("Equipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorasMtto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Horometro")
                        .HasColumnType("int");

                    b.Property<int?>("HorometroMtto")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroEconomico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("capacidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fases")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMontacargas");

                    b.ToTable("MontacargasModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ProcesosCorrectivoModel", b =>
                {
                    b.Property<int>("ComponenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComponenteId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComponenteId");

                    b.ToTable("ProcesosCorrectivoModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.SalidaItem", b =>
                {
                    b.Property<int>("IdSalidaItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSalidaItem"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdAlmacen")
                        .HasColumnType("int");

                    b.Property<int>("IdSalidaA")
                        .HasColumnType("int");

                    b.Property<int>("SalidaModelIdSalidaA")
                        .HasColumnType("int");

                    b.HasKey("IdSalidaItem");

                    b.HasIndex("IdAlmacen");

                    b.HasIndex("SalidaModelIdSalidaA");

                    b.ToTable("SalidaItem");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.SalidaModel", b =>
                {
                    b.Property<int>("IdSalidaA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSalidaA"), 1L, 1);

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaEntrego")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaRecibio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdAlmacen")
                        .HasColumnType("int");

                    b.Property<int?>("IdClientes")
                        .HasColumnType("int");

                    b.Property<int?>("IdMontacargas")
                        .HasColumnType("int");

                    b.Property<string>("NombreEntrego")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreRecibio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSalidaA");

                    b.HasIndex("IdAlmacen");

                    b.HasIndex("IdClientes");

                    b.HasIndex("IdMontacargas");

                    b.ToTable("SalidaModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ServicioCModel", b =>
                {
                    b.Property<int>("idServicioC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idServicioC"), 1L, 1);

                    b.Property<string>("FechaE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSalidaA")
                        .HasColumnType("int");

                    b.Property<string>("Refacciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServicioD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TareaId")
                        .HasColumnType("int");

                    b.HasKey("idServicioC");

                    b.HasIndex("IdSalidaA");

                    b.HasIndex("TareaId");

                    b.ToTable("ServicioCModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ServicioPModel", b =>
                {
                    b.Property<int>("IdServicioP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicioP"), 1L, 1);

                    b.Property<string>("AceiteDif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ajuste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlarmaReversa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alternador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anticongelante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Asiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BandaV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BateriaTermi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirlosTurcas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bobina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CablePedal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CablesB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cantidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CapuchoBujia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CilindroM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CinturonS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Claxon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crucetas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CubiertaP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distribuidor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EdoNivelA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EdoyNivelA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElementosAire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eslabon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Espejos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extintor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filtro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiltroAceiteMotor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiltroT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenoEst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fugas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FugasA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FugasF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FugasSH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FugasSistema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Golpes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horquillas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdClientes")
                        .HasColumnType("int");

                    b.Property<int>("IdMontacargas")
                        .HasColumnType("int");

                    b.Property<string>("Indicadores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Limpieza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Llantas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LlantasTM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LucesTrab")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MangosDire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MangueConex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MangueraRI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MangueraRS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mangueras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mezclador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotorA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelAceiteMotor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelLiquidoF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoParte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PastillaC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PernosEslabon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pintura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlafonAssy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purgar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Radiador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepuestoMezclador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepuestoVaporizador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespaldoC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespuestoValVacio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RotorD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Selenoide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelloCapBujia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServicioLyE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwitchE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tablero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TanqueGas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TapaD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tiempo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Torreta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValvulaVacio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vaporizador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ventilador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VálvulasPCV")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdServicioP");

                    b.HasIndex("IdClientes");

                    b.HasIndex("IdMontacargas");

                    b.ToTable("ServicioPModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ServicioPModel+Producto", b =>
                {
                    b.Property<int>("idProductoSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProductoSP"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoParte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServicioPModelIdServicioP")
                        .HasColumnType("int");

                    b.HasKey("idProductoSP");

                    b.HasIndex("ServicioPModelIdServicioP");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.Tarea", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TareaId"), 1L, 1);

                    b.Property<int>("ComponenteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServicioCModelidServicioC")
                        .HasColumnType("int");

                    b.HasKey("TareaId");

                    b.HasIndex("ComponenteId");

                    b.HasIndex("ServicioCModelidServicioC");

                    b.ToTable("Tarea");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.UsuariosModel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("ApellidoM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApellidoP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rolUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("UsuariosModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ChecklistModel", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.ClientesModel", "Clientes")
                        .WithMany()
                        .HasForeignKey("IdClientes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicioMontacargas.Models.MontacargasModel", "Montacargas")
                        .WithMany()
                        .HasForeignKey("IdMontacargas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Montacargas");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.EntregaMntCrgModel", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.MontacargasModel", "Montacargas")
                        .WithMany()
                        .HasForeignKey("IdMontacargas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Montacargas");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.SalidaItem", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.AlmacenModel", "Almacen")
                        .WithMany()
                        .HasForeignKey("IdAlmacen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicioMontacargas.Models.SalidaModel", "SalidaModel")
                        .WithMany("SalidaItems")
                        .HasForeignKey("SalidaModelIdSalidaA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Almacen");

                    b.Navigation("SalidaModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.SalidaModel", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.AlmacenModel", "Almacen")
                        .WithMany()
                        .HasForeignKey("IdAlmacen");

                    b.HasOne("ServicioMontacargas.Models.ClientesModel", "Clientes")
                        .WithMany()
                        .HasForeignKey("IdClientes");

                    b.HasOne("ServicioMontacargas.Models.MontacargasModel", "Montacargas")
                        .WithMany()
                        .HasForeignKey("IdMontacargas");

                    b.Navigation("Almacen");

                    b.Navigation("Clientes");

                    b.Navigation("Montacargas");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ServicioCModel", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.SalidaModel", "Salidas")
                        .WithMany()
                        .HasForeignKey("IdSalidaA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicioMontacargas.Models.Tarea", "Tareas")
                        .WithMany()
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salidas");

                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ServicioPModel", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.ClientesModel", "Clientes")
                        .WithMany()
                        .HasForeignKey("IdClientes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicioMontacargas.Models.MontacargasModel", "Montacargas")
                        .WithMany()
                        .HasForeignKey("IdMontacargas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Montacargas");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ServicioPModel+Producto", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.ServicioPModel", null)
                        .WithMany("Productos")
                        .HasForeignKey("ServicioPModelIdServicioP");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.Tarea", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.ProcesosCorrectivoModel", "Componente")
                        .WithMany("Tareas")
                        .HasForeignKey("ComponenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicioMontacargas.Models.ServicioCModel", null)
                        .WithMany("TareasSeleccionadas")
                        .HasForeignKey("ServicioCModelidServicioC");

                    b.Navigation("Componente");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ProcesosCorrectivoModel", b =>
                {
                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.SalidaModel", b =>
                {
                    b.Navigation("SalidaItems");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ServicioCModel", b =>
                {
                    b.Navigation("TareasSeleccionadas");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.ServicioPModel", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
