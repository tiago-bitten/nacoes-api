using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alterandorelacaoentregrupoevoluntario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_grupos_voluntarios_voluntario_id",
                table: "grupos_voluntarios");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_voluntarios_voluntario_id",
                table: "grupos_voluntarios",
                column: "voluntario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_grupos_voluntarios_voluntario_id",
                table: "grupos_voluntarios");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_voluntarios_voluntario_id",
                table: "grupos_voluntarios",
                column: "voluntario_id",
                unique: true);
        }
    }
}
