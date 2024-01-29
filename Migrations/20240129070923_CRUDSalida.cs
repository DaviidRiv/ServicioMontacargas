using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CRUDSalida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalidaModel",
                columns: table => new
                {
                    IdSalidaA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMontacargas = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    FirmaRecibio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaEntrego = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaModel", x => x.IdSalidaA);
                    table.ForeignKey(
                        name: "FK_SalidaModel_MontacargasModel_IdMontacargas",
                        column: x => x.IdMontacargas,
                        principalTable: "MontacargasModel",
                        principalColumn: "IdMontacargas");
                });

            migrationBuilder.CreateTable(
                name: "SalidaItem",
                columns: table => new
                {
                    IdSalidaItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlmacen = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    SalidaModelIdSalidaA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaItem", x => x.IdSalidaItem);
                    table.ForeignKey(
                        name: "FK_SalidaItem_AlmacenModel_IdAlmacen",
                        column: x => x.IdAlmacen,
                        principalTable: "AlmacenModel",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalidaItem_SalidaModel_SalidaModelIdSalidaA",
                        column: x => x.SalidaModelIdSalidaA,
                        principalTable: "SalidaModel",
                        principalColumn: "IdSalidaA");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalidaItem_IdAlmacen",
                table: "SalidaItem",
                column: "IdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaItem_SalidaModelIdSalidaA",
                table: "SalidaItem",
                column: "SalidaModelIdSalidaA");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaModel_IdMontacargas",
                table: "SalidaModel",
                column: "IdMontacargas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalidaItem");

            migrationBuilder.DropTable(
                name: "SalidaModel");
        }
    }
}
