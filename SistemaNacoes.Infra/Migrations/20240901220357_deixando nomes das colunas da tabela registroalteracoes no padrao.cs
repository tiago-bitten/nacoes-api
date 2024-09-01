using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class deixandonomesdascolunasdatabelaregistroalteracoesnopadrao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tabela",
                table: "registros_alteracoes",
                newName: "tabela");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "registros_alteracoes",
                newName: "item_id");

            migrationBuilder.AlterColumn<string>(
                name: "tabela",
                table: "registros_alteracoes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "item_id",
                table: "registros_alteracoes",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tabela",
                table: "registros_alteracoes",
                newName: "Tabela");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "registros_alteracoes",
                newName: "ItemId");

            migrationBuilder.AlterColumn<string>(
                name: "Tabela",
                table: "registros_alteracoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "registros_alteracoes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");
        }
    }
}
