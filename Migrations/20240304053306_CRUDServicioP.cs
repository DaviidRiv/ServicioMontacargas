using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CRUDServicioP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicioPModel",
                columns: table => new
                {
                    IdServicioP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClientes = table.Column<int>(type: "int", nullable: false),
                    IdMontacargas = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiltroAceiteMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementosAire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VálvulasPCV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limpieza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fugas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapuchoBujia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelloCapBujia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tiempo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vaporizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValvulaVacio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mezclador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepuestoVaporizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepuestoMezclador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespuestoValVacio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Selenoide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filtro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanqueGas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MangueConex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugasSistema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alternador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BateriaTermi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indicadores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anticongelante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandaV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MangueraRS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MangueraRI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Radiador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ventilador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotorA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bobina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CablesB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TapaD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RotorD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastillaC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distribuidor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwitchE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdoNivelA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiltroT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugasA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mangueras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CablePedal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MangosDire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eslabon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PernosEslabon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Llantas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirlosTurcas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdoyNivelA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugasSH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelLiquidoF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CilindroM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ajuste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purgar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugasF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrenoEst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AceiteDif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crucetas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasTM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesTrab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlafonAssy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Torreta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlarmaReversa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Claxon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extintor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Espejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CinturonS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespaldoC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horquillas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Golpes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tablero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pintura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CubiertaP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioLyE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoParte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioPModel", x => x.IdServicioP);
                    table.ForeignKey(
                        name: "FK_ServicioPModel_ClientesModel_IdClientes",
                        column: x => x.IdClientes,
                        principalTable: "ClientesModel",
                        principalColumn: "IdClientes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioPModel_MontacargasModel_IdMontacargas",
                        column: x => x.IdMontacargas,
                        principalTable: "MontacargasModel",
                        principalColumn: "IdMontacargas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProductoSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    NoParte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioPModelIdServicioP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.idProductoSP);
                    table.ForeignKey(
                        name: "FK_Producto_ServicioPModel_ServicioPModelIdServicioP",
                        column: x => x.ServicioPModelIdServicioP,
                        principalTable: "ServicioPModel",
                        principalColumn: "IdServicioP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ServicioPModelIdServicioP",
                table: "Producto",
                column: "ServicioPModelIdServicioP");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioPModel_IdClientes",
                table: "ServicioPModel",
                column: "IdClientes");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioPModel_IdMontacargas",
                table: "ServicioPModel",
                column: "IdMontacargas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "ServicioPModel");
        }
    }
}
