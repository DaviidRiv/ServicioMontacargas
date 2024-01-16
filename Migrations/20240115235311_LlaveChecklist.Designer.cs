﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicioMontacargas.Data;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    [DbContext(typeof(ServicioMontacargasContext))]
    [Migration("20240115235311_LlaveChecklist")]
    partial class LlaveChecklist
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<int>("idMontacargas")
                        .HasColumnType("int");

                    b.HasKey("IdEntregaMntCrg");

                    b.HasIndex("idMontacargas");

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
                    b.HasOne("ServicioMontacargas.Models.MontacargasModel", "Montacarga")
                        .WithMany()
                        .HasForeignKey("idMontacargas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Montacarga");
                });
#pragma warning restore 612, 618
        }
    }
}
