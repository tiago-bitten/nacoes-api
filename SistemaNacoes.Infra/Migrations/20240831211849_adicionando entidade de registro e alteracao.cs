using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoentidadederegistroealteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "registros_alteracoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dadosantigos = table.Column<string>(name: "dados_antigos", type: "JSONB", nullable: false),
                    dadosnovos = table.Column<string>(name: "dados_novos", type: "JSONB", nullable: false),
                    Tabela = table.Column<string>(type: "text", nullable: true),
                    ItemId = table.Column<int>(type: "integer", nullable: true),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "INT", nullable: true),
                    data = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
                    ip = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    useragent = table.Column<string>(name: "user_agent", type: "VARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros_alteracoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_registros_alteracoes_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "registros_criacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tabela = table.Column<string>(type: "text", nullable: true),
                    ItemId = table.Column<int>(type: "integer", nullable: true),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "INT", nullable: true),
                    data = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
                    ip = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    useragent = table.Column<string>(name: "user_agent", type: "VARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros_criacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_registros_criacao_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registros_alteracoes_usuario_id",
                table: "registros_alteracoes",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_registros_criacao_usuario_id",
                table: "registros_criacao",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registros_alteracoes");

            migrationBuilder.DropTable(
                name: "registros_criacao");
        }
    }
}
