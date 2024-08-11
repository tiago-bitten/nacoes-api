using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionandosituacaoagendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "situacoes_agendamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ativo = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true),
                    descricao = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    agendamentoid = table.Column<int>(name: "agendamento_id", type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_situacoes_agendamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_situacoes_agendamentos_agendamentos_agendamento_id",
                        column: x => x.agendamentoid,
                        principalTable: "agendamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_situacoes_agendamentos_agendamento_id",
                table: "situacoes_agendamentos",
                column: "agendamento_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "situacoes_agendamentos");
        }
    }
}
