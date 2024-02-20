using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CRUDServicioCorrectivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicioCorrectivoModel",
                columns: table => new
                {
                    idServicioC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSalidaA = table.Column<int>(type: "int", nullable: false),
                    ComponenteId = table.Column<int>(type: "int", nullable: false),
                    FechaR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refacciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioD = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioCorrectivoModel", x => x.idServicioC);
                    table.ForeignKey(
                        name: "FK_ServicioCorrectivoModel_ProcesosCorrectivoModel_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "ProcesosCorrectivoModel",
                        principalColumn: "ComponenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioCorrectivoModel_SalidaModel_IdSalidaA",
                        column: x => x.IdSalidaA,
                        principalTable: "SalidaModel",
                        principalColumn: "IdSalidaA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCorrectivoModel_ComponenteId",
                table: "ServicioCorrectivoModel",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCorrectivoModel_IdSalidaA",
                table: "ServicioCorrectivoModel",
                column: "IdSalidaA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicioCorrectivoModel");
        }
    }
}
