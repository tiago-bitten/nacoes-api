using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionadogrupovoluntario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_voluntarios_grupos_grupo_id",
                table: "voluntarios");

            migrationBuilder.DropIndex(
                name: "IX_voluntarios_grupo_id",
                table: "voluntarios");

            migrationBuilder.DropColumn(
                name: "grupo_id",
                table: "voluntarios");

            migrationBuilder.CreateTable(
                name: "grupos_voluntarios",
                columns: table => new
                {
                    grupoid = table.Column<int>(name: "grupo_id", type: "INT", nullable: false),
                    voluntarioid = table.Column<int>(name: "voluntario_id", type: "INT", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos_voluntarios", x => new { x.grupoid, x.voluntarioid });
                    table.ForeignKey(
                        name: "FK_grupos_voluntarios_grupos_grupo_id",
                        column: x => x.grupoid,
                        principalTable: "grupos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_grupos_voluntarios_voluntarios_voluntario_id",
                        column: x => x.voluntarioid,
                        principalTable: "voluntarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_grupos_voluntarios_voluntario_id",
                table: "grupos_voluntarios",
                column: "voluntario_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grupos_voluntarios");

            migrationBuilder.AddColumn<int>(
                name: "grupo_id",
                table: "voluntarios",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_voluntarios_grupo_id",
                table: "voluntarios",
                column: "grupo_id");

            migrationBuilder.AddForeignKey(
                name: "FK_voluntarios_grupos_grupo_id",
                table: "voluntarios",
                column: "grupo_id",
                principalTable: "grupos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
