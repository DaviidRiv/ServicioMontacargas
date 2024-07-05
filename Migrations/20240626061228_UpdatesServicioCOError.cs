using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class UpdatesServicioCOError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicioTarea",
                columns: table => new
                {
                    ServicioCoModelId = table.Column<int>(type: "int", nullable: false),
                    TareaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioTarea", x => new { x.ServicioCoModelId, x.TareaId });
                    table.ForeignKey(
                        name: "FK_ServicioTarea_ServicioCoModel_ServicioCoModelId",
                        column: x => x.ServicioCoModelId,
                        principalTable: "ServicioCoModel",
                        principalColumn: "IdServicioCo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicioTarea_Tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tarea",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicioTarea_TareaId",
                table: "ServicioTarea",
                column: "TareaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicioTarea");
        }
    }
}
