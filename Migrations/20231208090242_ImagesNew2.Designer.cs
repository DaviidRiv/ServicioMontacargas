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
    [Migration("20231208090242_ImagesNew2")]
    partial class ImagesNew2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServicioMontacargas.Models.EntregaMntCrgModel", b =>
                {
                    b.Property<int>("IdEntregaMntCrg")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEntregaMntCrg"), 1L, 1);

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

                    b.Property<string>("Extintor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaroProximidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirmaCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenoEstacionamiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FugaSistemaGas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorometroEntrega")
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

                    b.Property<int?>("MontacargaIdMontacargas")
                        .HasColumnType("int");

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

                    b.HasIndex("MontacargaIdMontacargas");

                    b.ToTable("EntregaMntCrgModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.MontacargasModel", b =>
                {
                    b.Property<int>("IdMontacargas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMontacargas"), 1L, 1);

                    b.Property<int>("Horometro")
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

                    b.HasKey("IdMontacargas");

                    b.ToTable("MontacargasModel");
                });

            modelBuilder.Entity("ServicioMontacargas.Models.EntregaMntCrgModel", b =>
                {
                    b.HasOne("ServicioMontacargas.Models.MontacargasModel", "Montacarga")
                        .WithMany()
                        .HasForeignKey("MontacargaIdMontacargas");

                    b.Navigation("Montacarga");
                });
#pragma warning restore 612, 618
        }
    }
}
