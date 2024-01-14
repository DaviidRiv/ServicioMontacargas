using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CrudChecklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChecklistModel",
                columns: table => new
                {
                    IdChecklist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreOperador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    turno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMontacargas = table.Column<int>(type: "int", nullable: false),
                    horometro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAnticongelante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteHidraulico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelLiquidoFrenos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandaVentilador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanqueGasSoportes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrenoEstacionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugaSistemaGas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanciaFrenado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespaldoCarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horquillas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Golpes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tablero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinturaGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CubiertaPiston = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasTraccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BateriaTerminales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimpiezaGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Radiador = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Ruidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenciaImagen1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EvidenciaImagen1Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenciaImagen2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EvidenciaImagen2Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistModel", x => x.IdChecklist);
                    table.ForeignKey(
                        name: "FK_ChecklistModel_MontacargasModel_IdMontacargas",
                        column: x => x.IdMontacargas,
                        principalTable: "MontacargasModel",
                        principalColumn: "IdMontacargas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistModel_IdMontacargas",
                table: "ChecklistModel",
                column: "IdMontacargas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistModel");
        }
    }
}
