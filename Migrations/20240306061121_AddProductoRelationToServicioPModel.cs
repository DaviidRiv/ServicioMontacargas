using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class AddProductoRelationToServicioPModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ServicioPModel_ServicioPModelIdServicioP",
                table: "Producto");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioPModelIdServicioP",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_ServicioPModel_ServicioPModelIdServicioP",
                table: "Producto",
                column: "ServicioPModelIdServicioP",
                principalTable: "ServicioPModel",
                principalColumn: "IdServicioP",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ServicioPModel_ServicioPModelIdServicioP",
                table: "Producto");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioPModelIdServicioP",
                table: "Producto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_ServicioPModel_ServicioPModelIdServicioP",
                table: "Producto",
                column: "ServicioPModelIdServicioP",
                principalTable: "ServicioPModel",
                principalColumn: "IdServicioP");
        }
    }
}
