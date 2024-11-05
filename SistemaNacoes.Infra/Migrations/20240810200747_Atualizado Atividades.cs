using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AtualizadoAtividades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "motivo",
                table: "datas_indisponiveis",
                type: "VARCHAR(255)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "agendamentos_atividades",
                columns: table => new
                {
                    agendamentoid = table.Column<int>(name: "agendamento_id", type: "INT", nullable: false),
                    atividadeid = table.Column<int>(name: "atividade_id", type: "INT", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamentos_atividades", x => new { x.agendamentoid, x.atividadeid });
                    table.ForeignKey(
                        name: "FK_agendamentos_atividades_agendamentos_agendamento_id",
                        column: x => x.agendamentoid,
                        principalTable: "agendamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_agendamentos_atividades_atividades_atividade_id",
                        column: x => x.atividadeid,
                        principalTable: "atividades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_atividades_atividade_id",
                table: "agendamentos_atividades",
                column: "atividade_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamentos_atividades");

            migrationBuilder.DropColumn(
                name: "motivo",
                table: "datas_indisponiveis");
        }
    }
}
