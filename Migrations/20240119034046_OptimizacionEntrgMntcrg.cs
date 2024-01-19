using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class OptimizacionEntrgMntcrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaMntCrgModel_MontacargasModel_idMontacargas",
                table: "EntregaMntCrgModel");

            migrationBuilder.RenameColumn(
                name: "idMontacargas",
                table: "EntregaMntCrgModel",
                newName: "IdMontacargas");

            migrationBuilder.RenameIndex(
                name: "IX_EntregaMntCrgModel_idMontacargas",
                table: "EntregaMntCrgModel",
                newName: "IX_EntregaMntCrgModel_IdMontacargas");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaMntCrgModel_MontacargasModel_IdMontacargas",
                table: "EntregaMntCrgModel",
                column: "IdMontacargas",
                principalTable: "MontacargasModel",
                principalColumn: "IdMontacargas",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaMntCrgModel_MontacargasModel_IdMontacargas",
                table: "EntregaMntCrgModel");

            migrationBuilder.RenameColumn(
                name: "IdMontacargas",
                table: "EntregaMntCrgModel",
                newName: "idMontacargas");

            migrationBuilder.RenameIndex(
                name: "IX_EntregaMntCrgModel_IdMontacargas",
                table: "EntregaMntCrgModel",
                newName: "IX_EntregaMntCrgModel_idMontacargas");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaMntCrgModel_MontacargasModel_idMontacargas",
                table: "EntregaMntCrgModel",
                column: "idMontacargas",
                principalTable: "MontacargasModel",
                principalColumn: "IdMontacargas",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
