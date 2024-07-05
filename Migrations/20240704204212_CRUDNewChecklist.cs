using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioMontacargas.Migrations
{
    public partial class CRUDNewChecklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioCoModel_Tarea_TareaId",
                table: "ServicioCoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_ServicioCoModelIdServicioCo",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_ServicioCoModel_TareaId",
                table: "ServicioCoModel");

            migrationBuilder.DropColumn(
                name: "ServicioCoModelId",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "ServicioCoModelIdServicioCo",
                table: "Tarea");

            migrationBuilder.AlterColumn<int>(
                name: "TareaId",
                table: "ServicioCoModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ChequeoDiarioModel",
                columns: table => new
                {
                    IdChequeoDiario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorometroActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMontacargas = table.Column<int>(type: "int", nullable: true),
                    NivelAceiteMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelRefrigerante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugaLineaGas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncPedestalFreno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrenoMano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FugasAceiteH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicadoresTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicadoresVolt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicadoresPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TensionCadenas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlantasBirlos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondicionesGnrls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalancaAvanceReversa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaLevante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipoSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LucesTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Claxon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Torreta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extintor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CinturonSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspejoRetrovisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alarma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlafonStop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacidadCarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreOperador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaOperador = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequeoDiarioModel", x => x.IdChequeoDiario);
                    table.ForeignKey(
                        name: "FK_ChequeoDiarioModel_MontacargasModel_IdMontacargas",
                        column: x => x.IdMontacargas,
                        principalTable: "MontacargasModel",
                        principalColumn: "IdMontacargas");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChequeoDiarioModel_IdMontacargas",
                table: "ChequeoDiarioModel",
                column: "IdMontacargas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChequeoDiarioModel");

            migrationBuilder.AddColumn<int>(
                name: "ServicioCoModelId",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicioCoModelIdServicioCo",
                table: "Tarea",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TareaId",
                table: "ServicioCoModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_ServicioCoModelIdServicioCo",
                table: "Tarea",
                column: "ServicioCoModelIdServicioCo");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCoModel_TareaId",
                table: "ServicioCoModel",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioCoModel_Tarea_TareaId",
                table: "ServicioCoModel",
                column: "TareaId",
                principalTable: "Tarea",
                principalColumn: "TareaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_ServicioCoModel_ServicioCoModelIdServicioCo",
                table: "Tarea",
                column: "ServicioCoModelIdServicioCo",
                principalTable: "ServicioCoModel",
                principalColumn: "IdServicioCo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
