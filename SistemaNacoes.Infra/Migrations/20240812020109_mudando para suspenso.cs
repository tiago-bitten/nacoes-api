using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class mudandoparasuspenso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ativo",
                table: "datas_indisponiveis");

            migrationBuilder.AddColumn<bool>(
                name: "suspenso",
                table: "datas_indisponiveis",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "suspenso",
                table: "datas_indisponiveis");

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "datas_indisponiveis",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: true);
        }
    }
}
