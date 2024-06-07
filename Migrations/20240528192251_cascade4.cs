using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class cascade4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_ProcesosCorrectivoModel_ComponenteId",
                table: "Tarea");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_ProcesosCorrectivoModel_ComponenteId",
                table: "Tarea",
                column: "ComponenteId",
                principalTable: "ProcesosCorrectivoModel",
                principalColumn: "ComponenteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_ProcesosCorrectivoModel_ComponenteId",
                table: "Tarea");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_ProcesosCorrectivoModel_ComponenteId",
                table: "Tarea",
                column: "ComponenteId",
                principalTable: "ProcesosCorrectivoModel",
                principalColumn: "ComponenteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
