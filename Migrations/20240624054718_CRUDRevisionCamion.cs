using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CRUDRevisionCamion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RevisionCamionModel",
                columns: table => new
                {
                    IdRevisionCamion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelCombustible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kilometraje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMontacargas = table.Column<int>(type: "int", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteTrans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteDirec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAceiteHidrau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefrigeranteMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiquidoFrenos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Radiador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicadorCombus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicadorTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicadorPresionA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BateriayTerminales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frenos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrenosEstac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineasAire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspensionD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Muelles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinturayC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdenyLG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasDelanteras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasTraserasLD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasTraserasLI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesDelanterasB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesDelanterasA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesTraseras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesFreno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesIntermitentes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesDireccionales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Claxon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlarmaReversa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limpiaparabrisas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspejosRetrovisores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParabrisasVD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedallonVT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VidrioLD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VidrioLI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AleronD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AleronI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extintor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaponC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreOperador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaOperador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreInspector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaInspector = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionCamionModel", x => x.IdRevisionCamion);
                    table.ForeignKey(
                        name: "FK_RevisionCamionModel_MontacargasModel_IdMontacargas",
                        column: x => x.IdMontacargas,
                        principalTable: "MontacargasModel",
                        principalColumn: "IdMontacargas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RevisionCamionModel_IdMontacargas",
                table: "RevisionCamionModel",
                column: "IdMontacargas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevisionCamionModel");
        }
    }
}
