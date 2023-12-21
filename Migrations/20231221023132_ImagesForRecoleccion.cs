using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class ImagesForRecoleccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<byte[]>(
                name: "EvidenciaRImagen1",
                table: "EntregaMntCrgModel",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvidenciaRImagen1Base64",
                table: "EntregaMntCrgModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "EvidenciaRImagen2",
                table: "EntregaMntCrgModel",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvidenciaRImagen2Base64",
                table: "EntregaMntCrgModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "EvidenciaRImagen1",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropColumn(
                name: "EvidenciaRImagen1Base64",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropColumn(
                name: "EvidenciaRImagen2",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropColumn(
                name: "EvidenciaRImagen2Base64",
                table: "EntregaMntCrgModel");
        }
    }
}
