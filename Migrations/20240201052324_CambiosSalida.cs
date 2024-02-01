using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CambiosSalida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaModel_MontacargasModel_IdAlmacen",
                table: "SalidaModel");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "SalidaModel");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaModel_AlmacenModel_IdAlmacen",
                table: "SalidaModel",
                column: "IdAlmacen",
                principalTable: "AlmacenModel",
                principalColumn: "IdAlmacen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaModel_AlmacenModel_IdAlmacen",
                table: "SalidaModel");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "SalidaModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaModel_MontacargasModel_IdAlmacen",
                table: "SalidaModel",
                column: "IdAlmacen",
                principalTable: "MontacargasModel",
                principalColumn: "IdMontacargas");
        }
    }
}
