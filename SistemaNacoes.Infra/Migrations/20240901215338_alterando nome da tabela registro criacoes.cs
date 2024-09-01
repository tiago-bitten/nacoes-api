using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alterandonomedatabelaregistrocriacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registros_criacao_usuarios_usuario_id",
                table: "registros_criacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_registros_criacao",
                table: "registros_criacao");

            migrationBuilder.RenameTable(
                name: "registros_criacao",
                newName: "registros_criacoes");

            migrationBuilder.RenameIndex(
                name: "IX_registros_criacao_usuario_id",
                table: "registros_criacoes",
                newName: "IX_registros_criacoes_usuario_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registros_criacoes",
                table: "registros_criacoes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_registros_criacoes_usuarios_usuario_id",
                table: "registros_criacoes",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registros_criacoes_usuarios_usuario_id",
                table: "registros_criacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_registros_criacoes",
                table: "registros_criacoes");

            migrationBuilder.RenameTable(
                name: "registros_criacoes",
                newName: "registros_criacao");

            migrationBuilder.RenameIndex(
                name: "IX_registros_criacoes_usuario_id",
                table: "registros_criacao",
                newName: "IX_registros_criacao_usuario_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registros_criacao",
                table: "registros_criacao",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_registros_criacao_usuarios_usuario_id",
                table: "registros_criacao",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
