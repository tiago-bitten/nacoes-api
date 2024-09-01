using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class deixandonomesdascolunasdatabelaregistrocriacoesnopadrao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tabela",
                table: "registros_criacoes",
                newName: "tabela");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "registros_criacoes",
                newName: "item_id");

            migrationBuilder.AlterColumn<string>(
                name: "tabela",
                table: "registros_criacoes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "item_id",
                table: "registros_criacoes",
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
                table: "registros_criacoes",
                newName: "Tabela");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "registros_criacoes",
                newName: "ItemId");

            migrationBuilder.AlterColumn<string>(
                name: "Tabela",
                table: "registros_criacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "registros_criacoes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");
        }
    }
}
