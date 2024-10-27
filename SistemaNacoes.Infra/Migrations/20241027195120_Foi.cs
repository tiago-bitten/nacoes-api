using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Foi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_agendas_agenda_id",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_ministerios_ministerio_id",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_voluntarios_voluntario_id",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_atividades_ministerios_ministerio_id",
                table: "atividades");

            migrationBuilder.DropForeignKey(
                name: "FK_datas_indisponiveis_voluntarios_voluntario_id",
                table: "datas_indisponiveis");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_agendas_agend_id",
                table: "escalas");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_ministerios_ministerio_id",
                table: "escalas");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_itens_atividades_atividade_id",
                table: "escalas_itens");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_itens_escalas_escala_id",
                table: "escalas_itens");

            migrationBuilder.DropForeignKey(
                name: "FK_escalas_itens_voluntarios_voluntario_id",
                table: "escalas_itens");

            migrationBuilder.DropForeignKey(
                name: "FK_grupos_ministerios_ministerio_preferencial_id",
                table: "grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_grupos_voluntarios_grupos_grupo_id",
                table: "grupos_voluntarios");

            migrationBuilder.DropForeignKey(
                name: "FK_grupos_voluntarios_voluntarios_voluntario_id",
                table: "grupos_voluntarios");

            migrationBuilder.DropForeignKey(
                name: "FK_situacoes_agendamentos_agendamentos_agendamento_id",
                table: "situacoes_agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_ministerios_ministerios_ministerio_id",
                table: "usuarios_ministerios");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_ministerios_usuarios_usuario_id",
                table: "usuarios_ministerios");

            migrationBuilder.DropForeignKey(
                name: "FK_voluntarios_ministerios_ministerios_ministerio_id",
                table: "voluntarios_ministerios");

            migrationBuilder.DropForeignKey(
                name: "FK_voluntarios_ministerios_voluntarios_voluntario_id",
                table: "voluntarios_ministerios");

            migrationBuilder.DropTable(
                name: "agendamentos_atividades");

            migrationBuilder.DropTable(
                name: "registros_alteracoes");

            migrationBuilder.DropTable(
                name: "registros_criacoes");

            migrationBuilder.DropTable(
                name: "registros_logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_voluntarios",
                table: "voluntarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refresh_tokens",
                table: "refresh_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ministerios",
                table: "ministerios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_grupos",
                table: "grupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_escalas",
                table: "escalas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_atividades",
                table: "atividades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agendas",
                table: "agendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agendamentos",
                table: "agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_voluntarios_ministerios",
                table: "voluntarios_ministerios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios_ministerios",
                table: "usuarios_ministerios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_situacoes_agendamentos",
                table: "situacoes_agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_grupos_voluntarios",
                table: "grupos_voluntarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_escalas_itens",
                table: "escalas_itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_datas_indisponiveis",
                table: "datas_indisponiveis");

            migrationBuilder.DropColumn(
                name: "permissoes",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "agendas");

            migrationBuilder.DropColumn(
                name: "finalizado",
                table: "agendas");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "usuarios_ministerios");

            migrationBuilder.RenameTable(
                name: "voluntarios_ministerios",
                newName: "voluntario_ministerios");

            migrationBuilder.RenameTable(
                name: "usuarios_ministerios",
                newName: "usuario_ministerios");

            migrationBuilder.RenameTable(
                name: "situacoes_agendamentos",
                newName: "situacao_agendamentos");

            migrationBuilder.RenameTable(
                name: "grupos_voluntarios",
                newName: "grupo_voluntarios");

            migrationBuilder.RenameTable(
                name: "escalas_itens",
                newName: "escala_itens");

            migrationBuilder.RenameTable(
                name: "datas_indisponiveis",
                newName: "data_indisponiveis");

            migrationBuilder.RenameIndex(
                name: "IX_grupos_ministerio_preferencial_id",
                table: "grupos",
                newName: "ix_grupos_ministerio_preferencial_id");

            migrationBuilder.RenameColumn(
                name: "agend_id",
                table: "escalas",
                newName: "agenda_id");

            migrationBuilder.RenameIndex(
                name: "IX_escalas_ministerio_id",
                table: "escalas",
                newName: "ix_escalas_ministerio_id");

            migrationBuilder.RenameIndex(
                name: "IX_escalas_agend_id",
                table: "escalas",
                newName: "ix_escalas_agenda_id");

            migrationBuilder.RenameIndex(
                name: "IX_atividades_ministerio_id",
                table: "atividades",
                newName: "ix_atividades_ministerio_id");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_voluntario_id",
                table: "agendamentos",
                newName: "ix_agendamentos_voluntario_id");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_ministerio_id",
                table: "agendamentos",
                newName: "ix_agendamentos_ministerio_id");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_agenda_id",
                table: "agendamentos",
                newName: "ix_agendamentos_agenda_id");

            migrationBuilder.RenameIndex(
                name: "IX_voluntarios_ministerios_voluntario_id",
                table: "voluntario_ministerios",
                newName: "ix_voluntario_ministerios_voluntario_id");

            migrationBuilder.RenameIndex(
                name: "IX_voluntarios_ministerios_ministerio_id",
                table: "voluntario_ministerios",
                newName: "ix_voluntario_ministerios_ministerio_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario_ministerios",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_ministerios_ministerio_id",
                table: "usuario_ministerios",
                newName: "ix_usuario_ministerios_ministerio_id");

            migrationBuilder.RenameIndex(
                name: "IX_situacoes_agendamentos_agendamento_id",
                table: "situacao_agendamentos",
                newName: "ix_situacao_agendamentos_agendamento_id");

            migrationBuilder.RenameIndex(
                name: "IX_grupos_voluntarios_voluntario_id",
                table: "grupo_voluntarios",
                newName: "ix_grupo_voluntarios_voluntario_id");

            migrationBuilder.RenameIndex(
                name: "IX_grupos_voluntarios_grupo_id",
                table: "grupo_voluntarios",
                newName: "ix_grupo_voluntarios_grupo_id");

            migrationBuilder.RenameIndex(
                name: "IX_escalas_itens_voluntario_id",
                table: "escala_itens",
                newName: "ix_escala_itens_voluntario_id");

            migrationBuilder.RenameIndex(
                name: "IX_escalas_itens_atividade_id",
                table: "escala_itens",
                newName: "ix_escala_itens_atividade_id");

            migrationBuilder.RenameIndex(
                name: "IX_datas_indisponiveis_voluntario_id",
                table: "data_indisponiveis",
                newName: "ix_data_indisponiveis_voluntario_id");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "voluntarios",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "voluntarios",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "voluntarios",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "voluntarios",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "voluntarios",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "chave_acesso",
                table: "voluntarios",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UUID");

            migrationBuilder.AlterColumn<string>(
                name: "celular",
                table: "voluntarios",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "voluntarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "voluntarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "senha_hash",
                table: "usuarios",
                type: "character varying(900)",
                maxLength: 900,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(900)");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "usuarios",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "usuarios",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "usuarios",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "usuarios",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "celular",
                table: "usuarios",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "usuarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "usuarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "perfil_acesso_id",
                table: "usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "refresh_tokens",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "revogado",
                table: "refresh_tokens",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "principal",
                table: "refresh_tokens",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_expiracao",
                table: "refresh_tokens",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP WITH TIME ZONE");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "refresh_tokens",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "refresh_tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "removido",
                table: "refresh_tokens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "ministerios",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "ministerios",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "ministerios",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "cor",
                table: "ministerios",
                type: "character varying(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7)");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "ministerios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "grupos",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "grupos",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_preferencial_id",
                table: "grupos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "grupos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "grupos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "usada",
                table: "escalas",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "escalas",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "quantidade_voluntarios",
                table: "escalas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "escalas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

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
                name: "agenda_id",
                table: "escalas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "escalas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "atividades",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "atividades",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "atividades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "maximo_voluntarios",
                table: "atividades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "atividades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "atividades",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "titulo",
                table: "agendas",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "agendas",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_inicio",
                table: "agendas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_final",
                table: "agendas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "agendas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "agendas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "removido",
                table: "agendas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "agendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "agendamentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "agendamentos",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "agendamentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "agenda_id",
                table: "agendamentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "agendamentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "agendamentos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "voluntario_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "voluntario_ministerios",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "voluntario_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "voluntario_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "voluntario_ministerios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "usuario_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "usuario_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "usuario_id",
                table: "usuario_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "usuario_ministerios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "removido",
                table: "usuario_ministerios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "situacao_agendamentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ativo",
                table: "situacao_agendamentos",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "agendamento_id",
                table: "situacao_agendamentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "situacao_agendamentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "situacao_agendamentos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "removido",
                table: "situacao_agendamentos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "grupo_voluntarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "grupo_voluntarios",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "grupo_id",
                table: "grupo_voluntarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "grupo_voluntarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "grupo_voluntarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "escala_itens",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "atividade_id",
                table: "escala_itens",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "escala_itens",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "escala_id",
                table: "escala_itens",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "escala_itens",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "escala_itens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "data_indisponiveis",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<bool>(
                name: "suspenso",
                table: "data_indisponiveis",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "data_indisponiveis",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "motivo",
                table: "data_indisponiveis",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_inicio",
                table: "data_indisponiveis",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_final",
                table: "data_indisponiveis",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "data_indisponiveis",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "data_indisponiveis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "pk_voluntarios",
                table: "voluntarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_usuarios",
                table: "usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_refresh_tokens",
                table: "refresh_tokens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_ministerios",
                table: "ministerios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_grupos",
                table: "grupos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_escalas",
                table: "escalas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_atividades",
                table: "atividades",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_agendas",
                table: "agendas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_agendamentos",
                table: "agendamentos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_voluntario_ministerios",
                table: "voluntario_ministerios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_usuario_ministerios",
                table: "usuario_ministerios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_situacao_agendamentos",
                table: "situacao_agendamentos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_grupo_voluntarios",
                table: "grupo_voluntarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_escala_itens",
                table: "escala_itens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_data_indisponiveis",
                table: "data_indisponiveis",
                column: "id");

            migrationBuilder.CreateTable(
                name: "agendamento_atividades",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agendamentoid = table.Column<int>(name: "agendamento_id", type: "integer", nullable: false),
                    atividadeid = table.Column<int>(name: "atividade_id", type: "integer", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    datacriacao = table.Column<DateTime>(name: "data_criacao", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agendamento_atividades", x => x.id);
                    table.ForeignKey(
                        name: "fk_agendamento_atividades_agendamentos",
                        column: x => x.agendamentoid,
                        principalTable: "agendamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_agendamento_atividades_atividades",
                        column: x => x.atividadeid,
                        principalTable: "atividades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "historico_entidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tabela = table.Column<string>(type: "text", nullable: false),
                    itemid = table.Column<int>(name: "item_id", type: "integer", nullable: false),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "integer", nullable: true),
                    data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ip = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    useragent = table.Column<string>(name: "user_agent", type: "character varying(300)", maxLength: 300, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    datacriacao = table.Column<DateTime>(name: "data_criacao", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_historico_entidades", x => x.id);
                    table.ForeignKey(
                        name: "fk_historico_entidades_usuarios",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "historico_logins",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "integer", nullable: true),
                    ip = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    useragent = table.Column<string>(name: "user_agent", type: "character varying(500)", maxLength: 500, nullable: false),
                    dataacesso = table.Column<DateTime>(name: "data_acesso", type: "timestamp with time zone", nullable: false),
                    sucesso = table.Column<bool>(type: "boolean", nullable: false),
                    motivo = table.Column<string>(type: "text", nullable: true),
                    removido = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    datacriacao = table.Column<DateTime>(name: "data_criacao", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_historico_logins", x => x.id);
                    table.ForeignKey(
                        name: "fk_historico_logins_usuarios",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "perfil_acessos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    permissoes = table.Column<long>(type: "bigint", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: false),
                    datacriacao = table.Column<DateTime>(name: "data_criacao", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_perfil_acessos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_usuarios_perfil_acesso_id",
                table: "usuarios",
                column: "perfil_acesso_id");

            migrationBuilder.CreateIndex(
                name: "ix_usuario_ministerios_usuario_id",
                table: "usuario_ministerios",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_escala_itens_escala_id",
                table: "escala_itens",
                column: "escala_id");

            migrationBuilder.CreateIndex(
                name: "ix_agendamento_atividades_agendamento_id",
                table: "agendamento_atividades",
                column: "agendamento_id");

            migrationBuilder.CreateIndex(
                name: "ix_agendamento_atividades_atividade_id",
                table: "agendamento_atividades",
                column: "atividade_id");

            migrationBuilder.CreateIndex(
                name: "ix_historico_entidades_usuario_id",
                table: "historico_entidades",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_historico_logins_usuario_id",
                table: "historico_logins",
                column: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "fk_agendamentos_agendas",
                table: "agendamentos",
                column: "agenda_id",
                principalTable: "agendas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_agendamentos_ministerios",
                table: "agendamentos",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_agendamentos_voluntarios",
                table: "agendamentos",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_atividades_ministerios",
                table: "atividades",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_data_indisponiveis_voluntarios",
                table: "data_indisponiveis",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_escala_itens_atividades",
                table: "escala_itens",
                column: "atividade_id",
                principalTable: "atividades",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_escala_itens_escalas",
                table: "escala_itens",
                column: "escala_id",
                principalTable: "escalas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_escala_itens_voluntarios",
                table: "escala_itens",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_escalas_agendas",
                table: "escalas",
                column: "agenda_id",
                principalTable: "agendas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_escalas_ministerios",
                table: "escalas",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_grupo_voluntarios_grupos",
                table: "grupo_voluntarios",
                column: "grupo_id",
                principalTable: "grupos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_grupo_voluntarios_voluntarios",
                table: "grupo_voluntarios",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_grupos_ministerios",
                table: "grupos",
                column: "ministerio_preferencial_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_situacao_agendamentos_agendamentos",
                table: "situacao_agendamentos",
                column: "agendamento_id",
                principalTable: "agendamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_usuario_ministerios_ministerios",
                table: "usuario_ministerios",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_usuario_ministerios_usuarios",
                table: "usuario_ministerios",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_usuarios_perfil_acessos",
                table: "usuarios",
                column: "perfil_acesso_id",
                principalTable: "perfil_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_voluntario_ministerios_ministerios",
                table: "voluntario_ministerios",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_voluntario_ministerios_voluntarios",
                table: "voluntario_ministerios",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_agendamentos_agendas",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "fk_agendamentos_ministerios",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "fk_agendamentos_voluntarios",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "fk_atividades_ministerios",
                table: "atividades");

            migrationBuilder.DropForeignKey(
                name: "fk_data_indisponiveis_voluntarios",
                table: "data_indisponiveis");

            migrationBuilder.DropForeignKey(
                name: "fk_escala_itens_atividades",
                table: "escala_itens");

            migrationBuilder.DropForeignKey(
                name: "fk_escala_itens_escalas",
                table: "escala_itens");

            migrationBuilder.DropForeignKey(
                name: "fk_escala_itens_voluntarios",
                table: "escala_itens");

            migrationBuilder.DropForeignKey(
                name: "fk_escalas_agendas",
                table: "escalas");

            migrationBuilder.DropForeignKey(
                name: "fk_escalas_ministerios",
                table: "escalas");

            migrationBuilder.DropForeignKey(
                name: "fk_grupo_voluntarios_grupos",
                table: "grupo_voluntarios");

            migrationBuilder.DropForeignKey(
                name: "fk_grupo_voluntarios_voluntarios",
                table: "grupo_voluntarios");

            migrationBuilder.DropForeignKey(
                name: "fk_grupos_ministerios",
                table: "grupos");

            migrationBuilder.DropForeignKey(
                name: "fk_situacao_agendamentos_agendamentos",
                table: "situacao_agendamentos");

            migrationBuilder.DropForeignKey(
                name: "fk_usuario_ministerios_ministerios",
                table: "usuario_ministerios");

            migrationBuilder.DropForeignKey(
                name: "fk_usuario_ministerios_usuarios",
                table: "usuario_ministerios");

            migrationBuilder.DropForeignKey(
                name: "fk_usuarios_perfil_acessos",
                table: "usuarios");

            migrationBuilder.DropForeignKey(
                name: "fk_voluntario_ministerios_ministerios",
                table: "voluntario_ministerios");

            migrationBuilder.DropForeignKey(
                name: "fk_voluntario_ministerios_voluntarios",
                table: "voluntario_ministerios");

            migrationBuilder.DropTable(
                name: "agendamento_atividades");

            migrationBuilder.DropTable(
                name: "historico_entidades");

            migrationBuilder.DropTable(
                name: "historico_logins");

            migrationBuilder.DropTable(
                name: "perfil_acessos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_voluntarios",
                table: "voluntarios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_usuarios",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "ix_usuarios_perfil_acesso_id",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_refresh_tokens",
                table: "refresh_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_ministerios",
                table: "ministerios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_grupos",
                table: "grupos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_escalas",
                table: "escalas");

            migrationBuilder.DropPrimaryKey(
                name: "pk_atividades",
                table: "atividades");

            migrationBuilder.DropPrimaryKey(
                name: "pk_agendas",
                table: "agendas");

            migrationBuilder.DropPrimaryKey(
                name: "pk_agendamentos",
                table: "agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_voluntario_ministerios",
                table: "voluntario_ministerios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_usuario_ministerios",
                table: "usuario_ministerios");

            migrationBuilder.DropIndex(
                name: "ix_usuario_ministerios_usuario_id",
                table: "usuario_ministerios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_situacao_agendamentos",
                table: "situacao_agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_grupo_voluntarios",
                table: "grupo_voluntarios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_escala_itens",
                table: "escala_itens");

            migrationBuilder.DropIndex(
                name: "ix_escala_itens_escala_id",
                table: "escala_itens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_data_indisponiveis",
                table: "data_indisponiveis");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "voluntarios");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "perfil_acesso_id",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "refresh_tokens");

            migrationBuilder.DropColumn(
                name: "removido",
                table: "refresh_tokens");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "ministerios");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "grupos");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "escalas");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "atividades");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "agendas");

            migrationBuilder.DropColumn(
                name: "removido",
                table: "agendas");

            migrationBuilder.DropColumn(
                name: "status",
                table: "agendas");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "voluntario_ministerios");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "usuario_ministerios");

            migrationBuilder.DropColumn(
                name: "removido",
                table: "usuario_ministerios");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "situacao_agendamentos");

            migrationBuilder.DropColumn(
                name: "removido",
                table: "situacao_agendamentos");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "grupo_voluntarios");

            migrationBuilder.DropColumn(
                name: "id",
                table: "escala_itens");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "escala_itens");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "data_indisponiveis");

            migrationBuilder.RenameTable(
                name: "voluntario_ministerios",
                newName: "voluntarios_ministerios");

            migrationBuilder.RenameTable(
                name: "usuario_ministerios",
                newName: "usuarios_ministerios");

            migrationBuilder.RenameTable(
                name: "situacao_agendamentos",
                newName: "situacoes_agendamentos");

            migrationBuilder.RenameTable(
                name: "grupo_voluntarios",
                newName: "grupos_voluntarios");

            migrationBuilder.RenameTable(
                name: "escala_itens",
                newName: "escalas_itens");

            migrationBuilder.RenameTable(
                name: "data_indisponiveis",
                newName: "datas_indisponiveis");

            migrationBuilder.RenameIndex(
                name: "ix_grupos_ministerio_preferencial_id",
                table: "grupos",
                newName: "IX_grupos_ministerio_preferencial_id");

            migrationBuilder.RenameColumn(
                name: "agenda_id",
                table: "escalas",
                newName: "agend_id");

            migrationBuilder.RenameIndex(
                name: "ix_escalas_ministerio_id",
                table: "escalas",
                newName: "IX_escalas_ministerio_id");

            migrationBuilder.RenameIndex(
                name: "ix_escalas_agenda_id",
                table: "escalas",
                newName: "IX_escalas_agend_id");

            migrationBuilder.RenameIndex(
                name: "ix_atividades_ministerio_id",
                table: "atividades",
                newName: "IX_atividades_ministerio_id");

            migrationBuilder.RenameIndex(
                name: "ix_agendamentos_voluntario_id",
                table: "agendamentos",
                newName: "IX_agendamentos_voluntario_id");

            migrationBuilder.RenameIndex(
                name: "ix_agendamentos_ministerio_id",
                table: "agendamentos",
                newName: "IX_agendamentos_ministerio_id");

            migrationBuilder.RenameIndex(
                name: "ix_agendamentos_agenda_id",
                table: "agendamentos",
                newName: "IX_agendamentos_agenda_id");

            migrationBuilder.RenameIndex(
                name: "ix_voluntario_ministerios_voluntario_id",
                table: "voluntarios_ministerios",
                newName: "IX_voluntarios_ministerios_voluntario_id");

            migrationBuilder.RenameIndex(
                name: "ix_voluntario_ministerios_ministerio_id",
                table: "voluntarios_ministerios",
                newName: "IX_voluntarios_ministerios_ministerio_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "usuarios_ministerios",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_usuario_ministerios_ministerio_id",
                table: "usuarios_ministerios",
                newName: "IX_usuarios_ministerios_ministerio_id");

            migrationBuilder.RenameIndex(
                name: "ix_situacao_agendamentos_agendamento_id",
                table: "situacoes_agendamentos",
                newName: "IX_situacoes_agendamentos_agendamento_id");

            migrationBuilder.RenameIndex(
                name: "ix_grupo_voluntarios_voluntario_id",
                table: "grupos_voluntarios",
                newName: "IX_grupos_voluntarios_voluntario_id");

            migrationBuilder.RenameIndex(
                name: "ix_grupo_voluntarios_grupo_id",
                table: "grupos_voluntarios",
                newName: "IX_grupos_voluntarios_grupo_id");

            migrationBuilder.RenameIndex(
                name: "ix_escala_itens_voluntario_id",
                table: "escalas_itens",
                newName: "IX_escalas_itens_voluntario_id");

            migrationBuilder.RenameIndex(
                name: "ix_escala_itens_atividade_id",
                table: "escalas_itens",
                newName: "IX_escalas_itens_atividade_id");

            migrationBuilder.RenameIndex(
                name: "ix_data_indisponiveis_voluntario_id",
                table: "datas_indisponiveis",
                newName: "IX_datas_indisponiveis_voluntario_id");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "voluntarios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "voluntarios",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "voluntarios",
                type: "VARCHAR(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "voluntarios",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "voluntarios",
                type: "VARCHAR(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "chave_acesso",
                table: "voluntarios",
                type: "UUID",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "celular",
                table: "voluntarios",
                type: "VARCHAR(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "voluntarios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "senha_hash",
                table: "usuarios",
                type: "VARCHAR(900)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(900)",
                oldMaxLength: 900);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "usuarios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "usuarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "usuarios",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "usuarios",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "usuarios",
                type: "VARCHAR(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "celular",
                table: "usuarios",
                type: "VARCHAR(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "usuarios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "permissoes",
                table: "usuarios",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "refresh_tokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "revogado",
                table: "refresh_tokens",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "principal",
                table: "refresh_tokens",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_expiracao",
                table: "refresh_tokens",
                type: "TIMESTAMP WITH TIME ZONE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "refresh_tokens",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "ministerios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "ministerios",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "ministerios",
                type: "VARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "cor",
                table: "ministerios",
                type: "VARCHAR(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "grupos",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "grupos",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_preferencial_id",
                table: "grupos",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "escalas",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "quantidade_voluntarios",
                table: "escalas",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "escalas",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "escalas",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "agend_id",
                table: "escalas",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "atividades",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "atividades",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "atividades",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "maximo_voluntarios",
                table: "atividades",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "atividades",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "titulo",
                table: "agendas",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "agendas",
                type: "VARCHAR(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_inicio",
                table: "agendas",
                type: "TIMESTAMP",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_final",
                table: "agendas",
                type: "TIMESTAMP",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "agendas",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "agendas",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "finalizado",
                table: "agendas",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "agendamentos",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "agendamentos",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "agendamentos",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "agenda_id",
                table: "agendamentos",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "agendamentos",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "voluntarios_ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "voluntarios_ministerios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "voluntarios_ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "voluntarios_ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "usuario_id",
                table: "usuarios_ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ministerio_id",
                table: "usuarios_ministerios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "usuarios_ministerios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "usuarios_ministerios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "situacoes_agendamentos",
                type: "VARCHAR(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ativo",
                table: "situacoes_agendamentos",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "agendamento_id",
                table: "situacoes_agendamentos",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "situacoes_agendamentos",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "grupos_voluntarios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "grupos_voluntarios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "grupo_id",
                table: "grupos_voluntarios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "grupos_voluntarios",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "escalas_itens",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "escalas_itens",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "escala_id",
                table: "escalas_itens",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "atividade_id",
                table: "escalas_itens",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "voluntario_id",
                table: "datas_indisponiveis",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "suspenso",
                table: "datas_indisponiveis",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "datas_indisponiveis",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "motivo",
                table: "datas_indisponiveis",
                type: "VARCHAR(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_inicio",
                table: "datas_indisponiveis",
                type: "TIMESTAMP",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_final",
                table: "datas_indisponiveis",
                type: "TIMESTAMP",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "datas_indisponiveis",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_voluntarios",
                table: "voluntarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refresh_tokens",
                table: "refresh_tokens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ministerios",
                table: "ministerios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_grupos",
                table: "grupos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_escalas",
                table: "escalas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_atividades",
                table: "atividades",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agendas",
                table: "agendas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agendamentos",
                table: "agendamentos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_voluntarios_ministerios",
                table: "voluntarios_ministerios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios_ministerios",
                table: "usuarios_ministerios",
                columns: new[] { "usuario_id", "ministerio_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_situacoes_agendamentos",
                table: "situacoes_agendamentos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_grupos_voluntarios",
                table: "grupos_voluntarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_escalas_itens",
                table: "escalas_itens",
                columns: new[] { "escala_id", "voluntario_id", "atividade_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_datas_indisponiveis",
                table: "datas_indisponiveis",
                column: "id");

            migrationBuilder.CreateTable(
                name: "agendamentos_atividades",
                columns: table => new
                {
                    agendamentoid = table.Column<int>(name: "agendamento_id", type: "INT", nullable: false),
                    atividadeid = table.Column<int>(name: "atividade_id", type: "INT", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamentos_atividades", x => new { x.agendamentoid, x.atividadeid });
                    table.ForeignKey(
                        name: "FK_agendamentos_atividades_agendamentos_agendamento_id",
                        column: x => x.agendamentoid,
                        principalTable: "agendamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_agendamentos_atividades_atividades_atividade_id",
                        column: x => x.atividadeid,
                        principalTable: "atividades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "registros_alteracoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "INT", nullable: true),
                    dadosantigos = table.Column<string>(name: "dados_antigos", type: "JSONB", nullable: false),
                    dadosnovos = table.Column<string>(name: "dados_novos", type: "JSONB", nullable: false),
                    data = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
                    ip = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    itemid = table.Column<int>(name: "item_id", type: "INT", nullable: false),
                    tabela = table.Column<string>(type: "TEXT", nullable: false),
                    useragent = table.Column<string>(name: "user_agent", type: "VARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros_alteracoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_registros_alteracoes_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "registros_criacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "INT", nullable: true),
                    data = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
                    ip = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    itemid = table.Column<int>(name: "item_id", type: "INT", nullable: false),
                    tabela = table.Column<string>(type: "TEXT", nullable: false),
                    useragent = table.Column<string>(name: "user_agent", type: "VARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros_criacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_registros_criacoes_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "registros_logins",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "INT", nullable: true),
                    data = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
                    ip = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    motivo = table.Column<string>(type: "TEXT", nullable: true),
                    sucesso = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    useragent = table.Column<string>(name: "user_agent", type: "VARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros_logins", x => x.id);
                    table.ForeignKey(
                        name: "FK_registros_logins_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_atividades_atividade_id",
                table: "agendamentos_atividades",
                column: "atividade_id");

            migrationBuilder.CreateIndex(
                name: "IX_registros_alteracoes_usuario_id",
                table: "registros_alteracoes",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_registros_criacoes_usuario_id",
                table: "registros_criacoes",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_registros_logins_usuario_id",
                table: "registros_logins",
                column: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_agendas_agenda_id",
                table: "agendamentos",
                column: "agenda_id",
                principalTable: "agendas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_ministerios_ministerio_id",
                table: "agendamentos",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_voluntarios_voluntario_id",
                table: "agendamentos",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_atividades_ministerios_ministerio_id",
                table: "atividades",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_datas_indisponiveis_voluntarios_voluntario_id",
                table: "datas_indisponiveis",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_agendas_agend_id",
                table: "escalas",
                column: "agend_id",
                principalTable: "agendas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_ministerios_ministerio_id",
                table: "escalas",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_itens_atividades_atividade_id",
                table: "escalas_itens",
                column: "atividade_id",
                principalTable: "atividades",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_itens_escalas_escala_id",
                table: "escalas_itens",
                column: "escala_id",
                principalTable: "escalas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_escalas_itens_voluntarios_voluntario_id",
                table: "escalas_itens",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_ministerios_ministerio_preferencial_id",
                table: "grupos",
                column: "ministerio_preferencial_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_voluntarios_grupos_grupo_id",
                table: "grupos_voluntarios",
                column: "grupo_id",
                principalTable: "grupos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_voluntarios_voluntarios_voluntario_id",
                table: "grupos_voluntarios",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_situacoes_agendamentos_agendamentos_agendamento_id",
                table: "situacoes_agendamentos",
                column: "agendamento_id",
                principalTable: "agendamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_ministerios_ministerios_ministerio_id",
                table: "usuarios_ministerios",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_ministerios_usuarios_usuario_id",
                table: "usuarios_ministerios",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_voluntarios_ministerios_ministerios_ministerio_id",
                table: "voluntarios_ministerios",
                column: "ministerio_id",
                principalTable: "ministerios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_voluntarios_ministerios_voluntarios_voluntario_id",
                table: "voluntarios_ministerios",
                column: "voluntario_id",
                principalTable: "voluntarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
