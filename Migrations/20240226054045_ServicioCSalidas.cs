using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class ServicioCSalidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSalidaA",
                table: "ServicioCModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCModel_IdSalidaA",
                table: "ServicioCModel",
                column: "IdSalidaA");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioCModel_SalidaModel_IdSalidaA",
                table: "ServicioCModel",
                column: "IdSalidaA",
                principalTable: "SalidaModel",
                principalColumn: "IdSalidaA",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioCModel_SalidaModel_IdSalidaA",
                table: "ServicioCModel");

            migrationBuilder.DropIndex(
                name: "IX_ServicioCModel_IdSalidaA",
                table: "ServicioCModel");

            migrationBuilder.DropColumn(
                name: "IdSalidaA",
                table: "ServicioCModel");
        }
    }
}
