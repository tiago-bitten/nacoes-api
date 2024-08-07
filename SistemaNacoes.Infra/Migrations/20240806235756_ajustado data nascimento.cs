using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajustadodatanascimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "voluntarios",
                newName: "data_nascimento");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "voluntarios",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "voluntarios",
                newName: "DataNascimento");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "voluntarios",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }
    }
}
