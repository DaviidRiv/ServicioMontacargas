using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class NewCamposMontacarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HorasMtto",
                table: "MontacargasModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HorometroMtto",
                table: "MontacargasModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cliente",
                table: "MontacargasModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasMtto",
                table: "MontacargasModel");

            migrationBuilder.DropColumn(
                name: "HorometroMtto",
                table: "MontacargasModel");

            migrationBuilder.DropColumn(
                name: "cliente",
                table: "MontacargasModel");
        }
    }
}
