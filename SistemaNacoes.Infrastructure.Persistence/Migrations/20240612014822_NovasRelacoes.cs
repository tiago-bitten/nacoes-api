using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NovasRelacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_escala_itens_atividades_atividade_id",
                table: "escala_itens");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_agendas_agenda_id",
                table: "escalas");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_ministerios_ministerio_id",
                table: "escalas");

            migrationBuilder.DropTable(
                name: "escalas_voluntarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_escala_itens",
                table: "escala_itens");

            migrationBuilder.AlterColumn<int>(
                name: "grupo_id",
                table: "voluntarios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "voluntarios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "usuarios_ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "usuario_id",
                table: "usuarios_ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "usuarios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "historicos",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "grupos",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "usada",
                table: "escalas",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "escalas",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "AgendaId1",
                table: "escalas",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinisterioId1",
                table: "escalas",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "voluntario_id",
                table: "escala_itens",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "datas_indisponiveis",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "atividades",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "agendas",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_escala_itens",
                table: "escala_itens",
                columns: new[] { "escala_id", "atividade_id", "voluntario_id" });

            migrationBuilder.CreateIndex(
                name: "IX_escalas_AgendaId1",
                table: "escalas",
                column: "AgendaId1");

            migrationBuilder.CreateIndex(
                name: "IX_escalas_MinisterioId1",
                table: "escalas",
                column: "MinisterioId1");

            migrationBuilder.CreateIndex(
                name: "IX_escala_itens_voluntario_id",
                table: "escala_itens",
                column: "voluntario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_escala_itens_atividades_atividade_id",
                table: "escala_itens",
                column: "atividade_id",
                principalTable: "atividades",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_escala_itens_voluntarios_voluntario_id",
                table: "escala_itens",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_agendas_AgendaId1",
                table: "escalas",
                column: "AgendaId1",
                principalTable: "agendas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_agendas_agenda_id",
                table: "escalas",
                column: "agenda_id",
                principalTable: "agendas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_ministerios_MinisterioId1",
                table: "escalas",
                column: "MinisterioId1",
                principalTable: "ministerios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_ministerios_ministerio_id",
                table: "escalas",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_escala_itens_atividades_atividade_id",
                table: "escala_itens");

            migrationBuilder.DropForeignKey(
                name: "FK_escala_itens_voluntarios_voluntario_id",
                table: "escala_itens");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_agendas_AgendaId1",
                table: "escalas");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_agendas_agenda_id",
                table: "escalas");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_ministerios_MinisterioId1",
                table: "escalas");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_ministerios_ministerio_id",
                table: "escalas");

            migrationBuilder.DropIndex(
                name: "IX_escalas_AgendaId1",
                table: "escalas");

            migrationBuilder.DropIndex(
                name: "IX_escalas_MinisterioId1",
                table: "escalas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_escala_itens",
                table: "escala_itens");

            migrationBuilder.DropIndex(
                name: "IX_escala_itens_voluntario_id",
                table: "escala_itens");

            migrationBuilder.DropColumn(
                name: "AgendaId1",
                table: "escalas");

            migrationBuilder.DropColumn(
                name: "MinisterioId1",
                table: "escalas");

            migrationBuilder.DropColumn(
                name: "voluntario_id",
                table: "escala_itens");

            migrationBuilder.AlterColumn<int>(
                name: "grupo_id",
                table: "voluntarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "voluntarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "usuarios_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "usuario_id",
                table: "usuarios_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "usuarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "historicos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "grupos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "usada",
                table: "escalas",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "escalas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "datas_indisponiveis",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "atividades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "agendas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_escala_itens",
                table: "escala_itens",
                columns: new[] { "escala_id", "atividade_id" });

            migrationBuilder.CreateTable(
                name: "escalas_voluntarios",
                columns: table => new
                {
                    escalaid = table.Column<int>(name: "escala_id", type: "INT", nullable: false),
                    atividadeid = table.Column<int>(name: "atividade_id", type: "INT", nullable: false),
                    voluntarioid = table.Column<int>(name: "voluntario_id", type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escalas_voluntarios", x => new { x.escalaid, x.atividadeid, x.voluntarioid });
                    table.ForeignKey(
                        name: "FK_escalas_voluntarios_atividades_atividade_id",
                        column: x => x.atividadeid,
                        principalTable: "atividades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_escalas_voluntarios_escalas_escala_id",
                        column: x => x.escalaid,
                        principalTable: "escalas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_escalas_voluntarios_voluntarios_voluntario_id",
                        column: x => x.voluntarioid,
                        principalTable: "voluntarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_escalas_voluntarios_atividade_id",
                table: "escalas_voluntarios",
                column: "atividade_id");

            migrationBuilder.CreateIndex(
                name: "IX_escalas_voluntarios_voluntario_id",
                table: "escalas_voluntarios",
                column: "voluntario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_escala_itens_atividades_atividade_id",
                table: "escala_itens",
                column: "atividade_id",
                principalTable: "atividades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_agendas_agenda_id",
                table: "escalas",
                column: "agenda_id",
                principalTable: "agendas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_ministerios_ministerio_id",
                table: "escalas",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
