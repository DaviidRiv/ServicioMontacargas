using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class Cascada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaItem_SalidaModel_SalidaModelIdSalidaA",
                table: "SalidaItem");

            migrationBuilder.AlterColumn<int>(
                name: "SalidaModelIdSalidaA",
                table: "SalidaItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaItem_SalidaModel_SalidaModelIdSalidaA",
                table: "SalidaItem",
                column: "SalidaModelIdSalidaA",
                principalTable: "SalidaModel",
                principalColumn: "IdSalidaA",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaItem_SalidaModel_SalidaModelIdSalidaA",
                table: "SalidaItem");

            migrationBuilder.AlterColumn<int>(
                name: "SalidaModelIdSalidaA",
                table: "SalidaItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaItem_SalidaModel_SalidaModelIdSalidaA",
                table: "SalidaItem",
                column: "SalidaModelIdSalidaA",
                principalTable: "SalidaModel",
                principalColumn: "IdSalidaA");
        }
    }
}
