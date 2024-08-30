using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoregistrodeloginshistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "registros_logins",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "INT", nullable: true),
                    ip = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    useragent = table.Column<string>(name: "user_agent", type: "VARCHAR(500)", nullable: false),
                    data = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
                    sucesso = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    motivo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros_logins", x => x.id);
                    table.ForeignKey(
                        name: "FK_registros_logins_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registros_logins_usuario_id",
                table: "registros_logins",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registros_logins");
        }
    }
}
