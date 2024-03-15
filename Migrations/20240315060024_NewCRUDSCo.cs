using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class NewCRUDSCo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_ServicioCModel_ServicioCModelidServicioC",
                table: "Tarea");

            migrationBuilder.DropTable(
                name: "ServicioCModel");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_ServicioCModelidServicioC",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "ServicioPModel");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ServicioPModel");

            migrationBuilder.DropColumn(
                name: "NoParte",
                table: "ServicioPModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cantidad",
                table: "ServicioPModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ServicioPModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoParte",
                table: "ServicioPModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServicioCModel",
                columns: table => new
                {
                    idServicioC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSalidaA = table.Column<int>(type: "int", nullable: false),
                    TareaId = table.Column<int>(type: "int", nullable: false),
                    FechaE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refacciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioCModel", x => x.idServicioC);
                    table.ForeignKey(
                        name: "FK_ServicioCModel_SalidaModel_IdSalidaA",
                        column: x => x.IdSalidaA,
                        principalTable: "SalidaModel",
                        principalColumn: "IdSalidaA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioCModel_Tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tarea",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_ServicioCModelidServicioC",
                table: "Tarea",
                column: "ServicioCModelidServicioC");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCModel_IdSalidaA",
                table: "ServicioCModel",
                column: "IdSalidaA");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCModel_TareaId",
                table: "ServicioCModel",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_ServicioCModel_ServicioCModelidServicioC",
                table: "Tarea",
                column: "ServicioCModelidServicioC",
                principalTable: "ServicioCModel",
                principalColumn: "idServicioC");
        }
    }
}
