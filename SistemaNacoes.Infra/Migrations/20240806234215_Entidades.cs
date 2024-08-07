using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    descricao = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    datainicio = table.Column<DateTime>(name: "data_inicio", type: "TIMESTAMP", nullable: false),
                    datafinal = table.Column<DateTime>(name: "data_final", type: "TIMESTAMP", nullable: false),
                    ativo = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ministerios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    cor = table.Column<string>(type: "VARCHAR(7)", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ministerios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    senhahash = table.Column<string>(name: "senha_hash", type: "VARCHAR(900)", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "atividades",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    maximovoluntarios = table.Column<string>(name: "maximo_voluntarios", type: "VARCHAR(150)", nullable: false),
                    ministerioid = table.Column<int>(name: "ministerio_id", type: "INT", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atividades", x => x.id);
                    table.ForeignKey(
                        name: "FK_atividades_ministerios_ministerio_id",
                        column: x => x.ministerioid,
                        principalTable: "ministerios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "escalas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidadevoluntarios = table.Column<int>(name: "quantidade_voluntarios", type: "INT", nullable: false),
                    agendid = table.Column<int>(name: "agend_id", type: "INT", nullable: false),
                    ministerioid = table.Column<int>(name: "ministerio_id", type: "INT", nullable: false),
                    usada = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escalas", x => x.id);
                    table.ForeignKey(
                        name: "FK_escalas_agendas_agend_id",
                        column: x => x.agendid,
                        principalTable: "agendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_escalas_ministerios_ministerio_id",
                        column: x => x.ministerioid,
                        principalTable: "ministerios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false),
                    ministeriopreferencialid = table.Column<int>(name: "ministerio_preferencial_id", type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos", x => x.id);
                    table.ForeignKey(
                        name: "FK_grupos_ministerios_ministerio_preferencial_id",
                        column: x => x.ministeriopreferencialid,
                        principalTable: "ministerios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_ministerios",
                columns: table => new
                {
                    usuarioid = table.Column<int>(name: "usuario_id", type: "INT", nullable: false),
                    ministerioid = table.Column<int>(name: "ministerio_id", type: "INT", nullable: false),
                    ativo = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_ministerios", x => new { x.usuarioid, x.ministerioid });
                    table.ForeignKey(
                        name: "FK_usuarios_ministerios_ministerios_ministerio_id",
                        column: x => x.ministerioid,
                        principalTable: "ministerios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_usuarios_ministerios_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "voluntarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chaveacesso = table.Column<Guid>(name: "chave_acesso", type: "UUID", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    cpf = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    grupoid = table.Column<int>(name: "grupo_id", type: "INT", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voluntarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_voluntarios_grupos_grupo_id",
                        column: x => x.grupoid,
                        principalTable: "grupos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "agendamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    voluntarioid = table.Column<int>(name: "voluntario_id", type: "INT", nullable: false),
                    ministerioid = table.Column<int>(name: "ministerio_id", type: "INT", nullable: false),
                    agendaid = table.Column<int>(name: "agenda_id", type: "INT", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_agendamentos_agendas_agenda_id",
                        column: x => x.agendaid,
                        principalTable: "agendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_agendamentos_ministerios_ministerio_id",
                        column: x => x.ministerioid,
                        principalTable: "ministerios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_agendamentos_voluntarios_voluntario_id",
                        column: x => x.voluntarioid,
                        principalTable: "voluntarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "datas_indisponiveis",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datainicio = table.Column<DateTime>(name: "data_inicio", type: "TIMESTAMP", nullable: false),
                    datafinal = table.Column<DateTime>(name: "data_final", type: "TIMESTAMP", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false),
                    voluntarioid = table.Column<int>(name: "voluntario_id", type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datas_indisponiveis", x => x.id);
                    table.ForeignKey(
                        name: "FK_datas_indisponiveis_voluntarios_voluntario_id",
                        column: x => x.voluntarioid,
                        principalTable: "voluntarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "escalas_itens",
                columns: table => new
                {
                    escalaid = table.Column<int>(name: "escala_id", type: "INT", nullable: false),
                    atividadeid = table.Column<int>(name: "atividade_id", type: "INT", nullable: false),
                    voluntarioid = table.Column<int>(name: "voluntario_id", type: "INT", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escalas_itens", x => new { x.escalaid, x.voluntarioid, x.atividadeid });
                    table.ForeignKey(
                        name: "FK_escalas_itens_atividades_atividade_id",
                        column: x => x.atividadeid,
                        principalTable: "atividades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_escalas_itens_escalas_escala_id",
                        column: x => x.escalaid,
                        principalTable: "escalas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_escalas_itens_voluntarios_voluntario_id",
                        column: x => x.voluntarioid,
                        principalTable: "voluntarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "voluntarios_ministerios",
                columns: table => new
                {
                    voluntarioid = table.Column<int>(name: "voluntario_id", type: "INT", nullable: false),
                    ministerioid = table.Column<int>(name: "ministerio_id", type: "INT", nullable: false),
                    ativo = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voluntarios_ministerios", x => new { x.voluntarioid, x.ministerioid });
                    table.ForeignKey(
                        name: "FK_voluntarios_ministerios_ministerios_ministerio_id",
                        column: x => x.ministerioid,
                        principalTable: "ministerios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_voluntarios_ministerios_voluntarios_voluntario_id",
                        column: x => x.voluntarioid,
                        principalTable: "voluntarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_agenda_id",
                table: "agendamentos",
                column: "agenda_id");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_ministerio_id",
                table: "agendamentos",
                column: "ministerio_id");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_voluntario_id",
                table: "agendamentos",
                column: "voluntario_id");

            migrationBuilder.CreateIndex(
                name: "IX_atividades_ministerio_id",
                table: "atividades",
                column: "ministerio_id");

            migrationBuilder.CreateIndex(
                name: "IX_datas_indisponiveis_voluntario_id",
                table: "datas_indisponiveis",
                column: "voluntario_id");

            migrationBuilder.CreateIndex(
                name: "IX_escalas_agend_id",
                table: "escalas",
                column: "agend_id");

            migrationBuilder.CreateIndex(
                name: "IX_escalas_ministerio_id",
                table: "escalas",
                column: "ministerio_id");

            migrationBuilder.CreateIndex(
                name: "IX_escalas_itens_atividade_id",
                table: "escalas_itens",
                column: "atividade_id");

            migrationBuilder.CreateIndex(
                name: "IX_escalas_itens_voluntario_id",
                table: "escalas_itens",
                column: "voluntario_id");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_ministerio_preferencial_id",
                table: "grupos",
                column: "ministerio_preferencial_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_ministerios_ministerio_id",
                table: "usuarios_ministerios",
                column: "ministerio_id");

            migrationBuilder.CreateIndex(
                name: "IX_voluntarios_grupo_id",
                table: "voluntarios",
                column: "grupo_id");

            migrationBuilder.CreateIndex(
                name: "IX_voluntarios_ministerios_ministerio_id",
                table: "voluntarios_ministerios",
                column: "ministerio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamentos");

            migrationBuilder.DropTable(
                name: "datas_indisponiveis");

            migrationBuilder.DropTable(
                name: "escalas_itens");

            migrationBuilder.DropTable(
                name: "usuarios_ministerios");

            migrationBuilder.DropTable(
                name: "voluntarios_ministerios");

            migrationBuilder.DropTable(
                name: "atividades");

            migrationBuilder.DropTable(
                name: "escalas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "voluntarios");

            migrationBuilder.DropTable(
                name: "agendas");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "ministerios");
        }
    }
}
