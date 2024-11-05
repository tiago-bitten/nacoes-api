using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoentidadebaseemgrupovoluntario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_grupos_voluntarios",
                table: "grupos_voluntarios");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "grupos_voluntarios",
                type: "INT",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_grupos_voluntarios",
                table: "grupos_voluntarios",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_voluntarios_grupo_id",
                table: "grupos_voluntarios",
                column: "grupo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_grupos_voluntarios",
                table: "grupos_voluntarios");

            migrationBuilder.DropIndex(
                name: "IX_grupos_voluntarios_grupo_id",
                table: "grupos_voluntarios");

            migrationBuilder.DropColumn(
                name: "id",
                table: "grupos_voluntarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_grupos_voluntarios",
                table: "grupos_voluntarios",
                columns: new[] { "grupo_id", "voluntario_id" });
        }
    }
}
