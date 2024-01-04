using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class fases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fases",
                table: "MontacargasModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fases",
                table: "MontacargasModel");
        }
    }
}
