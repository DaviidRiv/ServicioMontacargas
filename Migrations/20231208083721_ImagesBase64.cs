using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class ImagesBase64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvidenciaImagen1Base64",
                table: "EntregaMntCrgModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvidenciaImagen2Base64",
                table: "EntregaMntCrgModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvidenciaImagen1Base64",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropColumn(
                name: "EvidenciaImagen2Base64",
                table: "EntregaMntCrgModel");
        }
    }
}
