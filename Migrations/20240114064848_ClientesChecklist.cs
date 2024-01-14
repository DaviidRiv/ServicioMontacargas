using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class ClientesChecklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "empresa",
                table: "ChecklistModel");

            migrationBuilder.AddColumn<int>(
                name: "IdClientes",
                table: "ChecklistModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistModel_IdClientes",
                table: "ChecklistModel",
                column: "IdClientes");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistModel_ClientesModel_IdClientes",
                table: "ChecklistModel",
                column: "IdClientes",
                principalTable: "ClientesModel",
                principalColumn: "IdClientes",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistModel_ClientesModel_IdClientes",
                table: "ChecklistModel");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistModel_IdClientes",
                table: "ChecklistModel");

            migrationBuilder.DropColumn(
                name: "IdClientes",
                table: "ChecklistModel");

            migrationBuilder.AddColumn<string>(
                name: "empresa",
                table: "ChecklistModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
