using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class NewCambiosEnSalida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cliente",
                table: "SalidaModel",
                newName: "NombreRecibio");

            migrationBuilder.AddColumn<int>(
                name: "IdClientes",
                table: "SalidaModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreEntrego",
                table: "SalidaModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaModel_IdClientes",
                table: "SalidaModel",
                column: "IdClientes");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaModel_ClientesModel_IdClientes",
                table: "SalidaModel",
                column: "IdClientes",
                principalTable: "ClientesModel",
                principalColumn: "IdClientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaModel_ClientesModel_IdClientes",
                table: "SalidaModel");

            migrationBuilder.DropIndex(
                name: "IX_SalidaModel_IdClientes",
                table: "SalidaModel");

            migrationBuilder.DropColumn(
                name: "IdClientes",
                table: "SalidaModel");

            migrationBuilder.DropColumn(
                name: "NombreEntrego",
                table: "SalidaModel");

            migrationBuilder.RenameColumn(
                name: "NombreRecibio",
                table: "SalidaModel",
                newName: "Cliente");
        }
    }
}
