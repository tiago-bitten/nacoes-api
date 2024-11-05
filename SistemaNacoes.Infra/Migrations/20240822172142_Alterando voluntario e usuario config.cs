using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Alterandovoluntarioeusuarioconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "voluntarios",
                type: "VARCHAR(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AddColumn<string>(
                name: "celular",
                table: "voluntarios",
                type: "VARCHAR(15)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "celular",
                table: "usuarios",
                type: "VARCHAR(15)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "usuarios",
                type: "VARCHAR(11)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_nascimento",
                table: "usuarios",
                type: "DATE",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "celular",
                table: "voluntarios");

            migrationBuilder.DropColumn(
                name: "celular",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "data_nascimento",
                table: "usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "voluntarios",
                type: "VARCHAR(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldNullable: true);
        }
    }
}
