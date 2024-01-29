using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CRUDAlmacen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntregaMontacargaModel");

            migrationBuilder.CreateTable(
                name: "AlmacenModel",
                columns: table => new
                {
                    IdAlmacen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlmacenModel", x => x.IdAlmacen);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlmacenModel");

            migrationBuilder.CreateTable(
                name: "EntregaMontacargaModel",
                columns: table => new
                {
                    IdEntregaMntCrg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMontacargas = table.Column<int>(type: "int", nullable: false),
                    AceiteDiferencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlarmaReversa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BateriaTerminales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacidadCarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CinturonSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Claxon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CubiertaPiston = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanciaFrenado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementoAire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Espejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenciaImagen1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EvidenciaImagen1Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenciaImagen2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EvidenciaImagen2Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenciaRImagen1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EvidenciaRImagen1Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenciaRImagen2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EvidenciaRImagen2Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extintor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaroProximidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRecoleccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrenoEstacionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugaSistemaGas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorometroEntrega = table.Column<int>(type: "int", nullable: true),
                    HorometroRecoleccion = table.Column<int>(type: "int", nullable: true),
                    Horquillas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimpiezaGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasTraccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Llave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesTraseras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteHidraulico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAnticongelante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelLiquidoFrenos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreJacsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinturaGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespaldoCarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaArranque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tablero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanqueGasSoportes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Torreta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregaMontacargaModel", x => x.IdEntregaMntCrg);
                    table.ForeignKey(
                        name: "FK_EntregaMontacargaModel_MontacargasModel_IdMontacargas",
                        column: x => x.IdMontacargas,
                        principalTable: "MontacargasModel",
                        principalColumn: "IdMontacargas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaMontacargaModel_IdMontacargas",
                table: "EntregaMontacargaModel",
                column: "IdMontacargas");
        }
    }
}
