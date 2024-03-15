using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicioCoModelIdServicioCo",
                table: "Tarea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServicioCoModel",
                columns: table => new
                {
                    IdServicioCo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClientes = table.Column<int>(type: "int", nullable: false),
                    TareaId = table.Column<int>(type: "int", nullable: false),
                    CausaFalla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMontacargas = table.Column<int>(type: "int", nullable: false),
                    FechaReg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refacciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioCoModel", x => x.IdServicioCo);
                    table.ForeignKey(
                        name: "FK_ServicioCoModel_ClientesModel_IdClientes",
                        column: x => x.IdClientes,
                        principalTable: "ClientesModel",
                        principalColumn: "IdClientes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioCoModel_MontacargasModel_IdMontacargas",
                        column: x => x.IdMontacargas,
                        principalTable: "MontacargasModel",
                        principalColumn: "IdMontacargas",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioCoModel_Tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tarea",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoSCo",
                columns: table => new
                {
                    idProductoSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    NoParte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioPModelIdServicioCo = table.Column<int>(type: "int", nullable: false),
                    ServicioCoModelIdServicioCo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoSCo", x => x.idProductoSP);
                    table.ForeignKey(
                        name: "FK_ProductoSCo_ServicioCoModel_ServicioCoModelIdServicioCo",
                        column: x => x.ServicioCoModelIdServicioCo,
                        principalTable: "ServicioCoModel",
                        principalColumn: "IdServicioCo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_ServicioCoModelIdServicioCo",
                table: "Tarea",
                column: "ServicioCoModelIdServicioCo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoSCo_ServicioCoModelIdServicioCo",
                table: "ProductoSCo",
                column: "ServicioCoModelIdServicioCo");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCoModel_IdClientes",
                table: "ServicioCoModel",
                column: "IdClientes");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCoModel_IdMontacargas",
                table: "ServicioCoModel",
                column: "IdMontacargas");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCoModel_TareaId",
                table: "ServicioCoModel",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "Tarea",
                column: "ServicioCoModelIdServicioCo",
                principalTable: "ServicioCoModel",
                principalColumn: "IdServicioCo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "Tarea");

            migrationBuilder.DropTable(
                name: "ProductoSCo");

            migrationBuilder.DropTable(
                name: "ServicioCoModel");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_ServicioCoModelIdServicioCo",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "ServicioCoModelIdServicioCo",
                table: "Tarea");
        }
    }
}
