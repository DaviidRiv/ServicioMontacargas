using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class LatLongEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UbicacionE",
                table: "EntradaSalidaModel");

            migrationBuilder.DropColumn(
                name: "UbicacionS",
                table: "EntradaSalidaModel");

            migrationBuilder.AddColumn<double>(
                name: "LatitudE",
                table: "EntradaSalidaModel",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LatitudS",
                table: "EntradaSalidaModel",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LongitudE",
                table: "EntradaSalidaModel",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LongitudS",
                table: "EntradaSalidaModel",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatitudE",
                table: "EntradaSalidaModel");

            migrationBuilder.DropColumn(
                name: "LatitudS",
                table: "EntradaSalidaModel");

            migrationBuilder.DropColumn(
                name: "LongitudE",
                table: "EntradaSalidaModel");

            migrationBuilder.DropColumn(
                name: "LongitudS",
                table: "EntradaSalidaModel");

            migrationBuilder.AddColumn<string>(
                name: "UbicacionE",
                table: "EntradaSalidaModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UbicacionS",
                table: "EntradaSalidaModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
