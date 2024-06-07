using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "Tarea");

            migrationBuilder.AddColumn<int>(
                name: "ServicioCoModelIdServicioCo1",
                table: "Tarea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_ServicioCoModelIdServicioCo1",
                table: "Tarea",
                column: "ServicioCoModelIdServicioCo1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "Tarea",
                column: "ServicioCoModelIdServicioCo",
                principalTable: "ServicioCoModel",
                principalColumn: "IdServicioCo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo1",
                table: "Tarea",
                column: "ServicioCoModelIdServicioCo1",
                principalTable: "ServicioCoModel",
                principalColumn: "IdServicioCo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "Tarea");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo1",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_ServicioCoModelIdServicioCo1",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "ServicioCoModelIdServicioCo1",
                table: "Tarea");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "Tarea",
                column: "ServicioCoModelIdServicioCo",
                principalTable: "ServicioCoModel",
                principalColumn: "IdServicioCo");
        }
    }
}
