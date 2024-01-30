using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class UpdateSalida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAlmacen",
                table: "SalidaModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaModel_IdAlmacen",
                table: "SalidaModel",
                column: "IdAlmacen");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaModel_MontacargasModel_IdAlmacen",
                table: "SalidaModel",
                column: "IdAlmacen",
                principalTable: "MontacargasModel",
                principalColumn: "IdMontacargas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaModel_MontacargasModel_IdAlmacen",
                table: "SalidaModel");

            migrationBuilder.DropIndex(
                name: "IX_SalidaModel_IdAlmacen",
                table: "SalidaModel");

            migrationBuilder.DropColumn(
                name: "IdAlmacen",
                table: "SalidaModel");
        }
    }
}
