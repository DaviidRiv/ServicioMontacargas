using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class ModfMontacargas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "capacidad",
                table: "MontacargasModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "MontacargasModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capacidad",
                table: "MontacargasModel");

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "MontacargasModel");
        }
    }
}
