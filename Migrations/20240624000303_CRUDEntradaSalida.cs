using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CRUDEntradaSalida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradaSalidaModel",
                columns: table => new
                {
                    IdEntradaSalida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaSalida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaSalidaModel", x => x.IdEntradaSalida);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaSalidaModel");
        }
    }
}
