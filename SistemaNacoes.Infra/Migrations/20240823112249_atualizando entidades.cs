using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    public partial class atualizandoentidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "ministerios",
                newName: "descricao");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "ministerios",
                type: "VARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.Sql(
                @"ALTER TABLE atividades 
                  ALTER COLUMN maximo_voluntarios 
                  TYPE INT USING maximo_voluntarios::integer;"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "ministerios",
                newName: "Descricao");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ministerios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "maximo_voluntarios",
                table: "atividades",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");
        }
    }
}