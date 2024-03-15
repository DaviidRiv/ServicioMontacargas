using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class cambioproductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoSCo_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "ProductoSCo");

            migrationBuilder.DropColumn(
                name: "ServicioPModelIdServicioCo",
                table: "ProductoSCo");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioCoModelIdServicioCo",
                table: "ProductoSCo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoSCo_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "ProductoSCo",
                column: "ServicioCoModelIdServicioCo",
                principalTable: "ServicioCoModel",
                principalColumn: "IdServicioCo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoSCo_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "ProductoSCo");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioCoModelIdServicioCo",
                table: "ProductoSCo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ServicioPModelIdServicioCo",
                table: "ProductoSCo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoSCo_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "ProductoSCo",
                column: "ServicioCoModelIdServicioCo",
                principalTable: "ServicioCoModel",
                principalColumn: "IdServicioCo");
        }
    }
}
