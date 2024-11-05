using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoidcolunanoagendamentosatividades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_agendamentos_atividades",
                table: "agendamentos_atividades");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "agendamentos_atividades",
                type: "INT",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_agendamentos_atividades",
                table: "agendamentos_atividades",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_atividades_agendamento_id",
                table: "agendamentos_atividades",
                column: "agendamento_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_agendamentos_atividades",
                table: "agendamentos_atividades");

            migrationBuilder.DropIndex(
                name: "IX_agendamentos_atividades_agendamento_id",
                table: "agendamentos_atividades");

            migrationBuilder.DropColumn(
                name: "id",
                table: "agendamentos_atividades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agendamentos_atividades",
                table: "agendamentos_atividades",
                columns: new[] { "agendamento_id", "atividade_id" });
        }
    }
}
