using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class UpdateEntregaMontacarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HorometroEntrega",
                table: "EntregaMntCrgModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AceiteDiferencial",
                table: "EntregaMntCrgModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRecoleccion",
                table: "EntregaMntCrgModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HorometroRecoleccion",
                table: "EntregaMntCrgModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreJacsa",
                table: "EntregaMntCrgModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AceiteDiferencial",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropColumn(
                name: "FechaRecoleccion",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropColumn(
                name: "HorometroRecoleccion",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropColumn(
                name: "NombreJacsa",
                table: "EntregaMntCrgModel");

            migrationBuilder.AlterColumn<int>(
                name: "HorometroEntrega",
                table: "EntregaMntCrgModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
