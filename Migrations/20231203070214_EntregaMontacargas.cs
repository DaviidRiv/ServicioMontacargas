using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class EntregaMontacargas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntregaMntCrgModel",
                columns: table => new
                {
                    IdEntregaMntCrg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorometroEntrega = table.Column<int>(type: "int", nullable: false),
                    MontacargaIdMontacargas = table.Column<int>(type: "int", nullable: true),
                    idMontacargas = table.Column<int>(type: "int", nullable: false),
                    NivelAceiteMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAnticongelante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteHidraulico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelLiquidoFrenos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanqueGasSoportes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrenoEstacionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugaSistemaGas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementoAire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanciaFrenado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacidadCarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespaldoCarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horquillas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tablero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinturaGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CubiertaPiston = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasTraccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BateriaTerminales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimpiezaGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaArranque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesTraseras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Torreta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlarmaReversa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Claxon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extintor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Espejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CinturonSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaroProximidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Llave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenciaImagen1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EvidenciaImagen2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregaMntCrgModel", x => x.IdEntregaMntCrg);
                    table.ForeignKey(
                        name: "FK_EntregaMntCrgModel_MontacargasModel_MontacargaIdMontacargas",
                        column: x => x.MontacargaIdMontacargas,
                        principalTable: "MontacargasModel",
                        principalColumn: "IdMontacargas");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaMntCrgModel_MontacargaIdMontacargas",
                table: "EntregaMntCrgModel",
                column: "MontacargaIdMontacargas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntregaMntCrgModel");
        }
    }
}
