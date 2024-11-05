using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoentidadebaseemvoluntarioministerio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_voluntarios_ministerios",
                table: "voluntarios_ministerios");

            migrationBuilder.AlterColumn<bool>(
                name: "ativo",
                table: "voluntarios_ministerios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "voluntarios_ministerios",
                type: "INT",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_voluntarios_ministerios",
                table: "voluntarios_ministerios",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_voluntarios_ministerios_voluntario_id",
                table: "voluntarios_ministerios",
                column: "voluntario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_voluntarios_ministerios",
                table: "voluntarios_ministerios");

            migrationBuilder.DropIndex(
                name: "IX_voluntarios_ministerios_voluntario_id",
                table: "voluntarios_ministerios");

            migrationBuilder.DropColumn(
                name: "id",
                table: "voluntarios_ministerios");

            migrationBuilder.AlterColumn<bool>(
                name: "ativo",
                table: "voluntarios_ministerios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_voluntarios_ministerios",
                table: "voluntarios_ministerios",
                columns: new[] { "voluntario_id", "ministerio_id" });
        }
    }
}
