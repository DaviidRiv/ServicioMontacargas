using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class RelacionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaMntCrgModel_MontacargasModel_MontacargaIdMontacargas",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropIndex(
                name: "IX_EntregaMntCrgModel_MontacargaIdMontacargas",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropColumn(
                name: "MontacargaIdMontacargas",
                table: "EntregaMntCrgModel");

            migrationBuilder.CreateIndex(
                name: "IX_EntregaMntCrgModel_idMontacargas",
                table: "EntregaMntCrgModel",
                column: "idMontacargas");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaMntCrgModel_MontacargasModel_idMontacargas",
                table: "EntregaMntCrgModel",
                column: "idMontacargas",
                principalTable: "MontacargasModel",
                principalColumn: "IdMontacargas",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaMntCrgModel_MontacargasModel_idMontacargas",
                table: "EntregaMntCrgModel");

            migrationBuilder.DropIndex(
                name: "IX_EntregaMntCrgModel_idMontacargas",
                table: "EntregaMntCrgModel");

            migrationBuilder.AddColumn<int>(
                name: "MontacargaIdMontacargas",
                table: "EntregaMntCrgModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntregaMntCrgModel_MontacargaIdMontacargas",
                table: "EntregaMntCrgModel",
                column: "MontacargaIdMontacargas");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaMntCrgModel_MontacargasModel_MontacargaIdMontacargas",
                table: "EntregaMntCrgModel",
                column: "MontacargaIdMontacargas",
                principalTable: "MontacargasModel",
                principalColumn: "IdMontacargas");
        }
    }
}
