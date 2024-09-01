﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaNacoes.Infra.Contexts;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    [DbContext(typeof(NacoesDbContext))]
    partial class NacoesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("data_final");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("data_inicio");

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("descricao");

                    b.Property<bool>("Finalizado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("finalizado");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.ToTable("agendas", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgendaId")
                        .HasColumnType("INT")
                        .HasColumnName("agenda_id");

                    b.Property<int>("MinisterioId")
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_id");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("INT")
                        .HasColumnName("voluntario_id");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("MinisterioId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("agendamentos", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.AgendamentoAtividade", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .HasColumnType("INT")
                        .HasColumnName("agendamento_id");

                    b.Property<int>("AtividadeId")
                        .HasColumnType("INT")
                        .HasColumnName("atividade_id");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("AgendamentoId", "AtividadeId");

                    b.HasIndex("AtividadeId");

                    b.ToTable("agendamentos_atividades", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MaximoVoluntarios")
                        .HasColumnType("INT")
                        .HasColumnName("maximo_voluntarios");

                    b.Property<int>("MinisterioId")
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("nome");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("Id");

                    b.HasIndex("MinisterioId");

                    b.ToTable("atividades", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.DataIndisponivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("data_final");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("data_inicio");

                    b.Property<string>("Motivo")
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("motivo");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.Property<bool>("Suspenso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("suspenso");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("INT")
                        .HasColumnName("voluntario_id");

                    b.HasKey("Id");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("datas_indisponiveis", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Escala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgendaId")
                        .HasColumnType("INT")
                        .HasColumnName("agend_id");

                    b.Property<int>("MinisterioId")
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_id");

                    b.Property<int>("QuantidadeVoluntarios")
                        .HasColumnType("INT")
                        .HasColumnName("quantidade_voluntarios");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.Property<bool>("Usada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("usada");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("MinisterioId");

                    b.ToTable("escalas", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.EscalaItem", b =>
                {
                    b.Property<int>("EscalaId")
                        .HasColumnType("INT")
                        .HasColumnName("escala_id");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("INT")
                        .HasColumnName("voluntario_id");

                    b.Property<int>("AtividadeId")
                        .HasColumnType("INT")
                        .HasColumnName("atividade_id");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("EscalaId", "VoluntarioId", "AtividadeId");

                    b.HasIndex("AtividadeId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("escalas_itens", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("MinisterioPreferencialId")
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_preferencial_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("nome");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("Id");

                    b.HasIndex("MinisterioPreferencialId");

                    b.ToTable("grupos", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.GrupoVoluntario", b =>
                {
                    b.Property<int>("GrupoId")
                        .HasColumnType("INT")
                        .HasColumnName("grupo_id");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("INT")
                        .HasColumnName("voluntario_id");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("GrupoId", "VoluntarioId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("grupos_voluntarios", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Ministerio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("VARCHAR(7)")
                        .HasColumnName("cor");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("nome");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("Id");

                    b.ToTable("ministerios", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("TIMESTAMP WITH TIME ZONE")
                        .HasColumnName("data_expiracao");

                    b.Property<string>("Principal")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("principal");

                    b.Property<bool>("Revogado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("revogado");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.ToTable("refresh_tokens", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.RegistroAlteracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DadosAntigos")
                        .IsRequired()
                        .HasColumnType("JSONB")
                        .HasColumnName("dados_antigos");

                    b.Property<string>("DadosNovos")
                        .IsRequired()
                        .HasColumnType("JSONB")
                        .HasColumnName("dados_novos");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TIMESTAMP WITH TIME ZONE")
                        .HasColumnName("data");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("ip");

                    b.Property<int?>("ItemId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("item_id");

                    b.Property<string>("Tabela")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("tabela");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("user_agent");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("INT")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("registros_alteracoes", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.RegistroCriacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("TIMESTAMP WITH TIME ZONE")
                        .HasColumnName("data");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("ip");

                    b.Property<int?>("ItemId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("item_id");

                    b.Property<string>("Tabela")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("tabela");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("user_agent");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("INT")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("registros_criacoes", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.RegistroLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("TIMESTAMP WITH TIME ZONE")
                        .HasColumnName("data");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("ip");

                    b.Property<string>("Motivo")
                        .HasColumnType("TEXT")
                        .HasColumnName("motivo");

                    b.Property<bool>("Sucesso")
                        .HasColumnType("BOOLEAN")
                        .HasColumnName("sucesso");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("user_agent");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("INT")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("registros_logins", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.SituacaoAgendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("INT")
                        .HasColumnName("agendamento_id");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(250)")
                        .HasColumnName("descricao");

                    b.HasKey("Id");

                    b.HasIndex("AgendamentoId")
                        .IsUnique();

                    b.ToTable("situacoes_agendamentos", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("celular");

                    b.Property<string>("Cpf")
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<long>("Permissoes")
                        .HasColumnType("BIGINT")
                        .HasColumnName("permissoes");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasColumnType("VARCHAR(900)")
                        .HasColumnName("senha_hash");

                    b.HasKey("Id");

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.UsuarioMinisterio", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("INT")
                        .HasColumnName("usuario_id");

                    b.Property<int>("MinisterioId")
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_id");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("UsuarioId", "MinisterioId");

                    b.HasIndex("MinisterioId");

                    b.ToTable("usuarios_ministerios", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Voluntario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("celular");

                    b.Property<Guid>("ChaveAcesso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("chave_acesso");

                    b.Property<string>("Cpf")
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("cpf");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("nome");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("Id");

                    b.ToTable("voluntarios", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.VoluntarioMinisterio", b =>
                {
                    b.Property<int>("VoluntarioId")
                        .HasColumnType("INT")
                        .HasColumnName("voluntario_id");

                    b.Property<int>("MinisterioId")
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_id");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.HasKey("VoluntarioId", "MinisterioId");

                    b.HasIndex("MinisterioId");

                    b.ToTable("voluntarios_ministerios", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Agendamento", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Agenda", "Agenda")
                        .WithMany("Agendamentos")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("Agendamentos")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("Ministerio");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.AgendamentoAtividade", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Agendamento", "Agendamento")
                        .WithMany("AgendamentoAtividades")
                        .HasForeignKey("AgendamentoId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Atividade", "Atividade")
                        .WithMany("AgendamentoAtividades")
                        .HasForeignKey("AtividadeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Agendamento");

                    b.Navigation("Atividade");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Atividade", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("Atividades")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Ministerio");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.DataIndisponivel", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("DatasIndisponiveis")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Escala", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Agenda", "Agenda")
                        .WithMany("Escalas")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("Escalas")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("Ministerio");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.EscalaItem", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Atividade", "Atividade")
                        .WithMany("EscalaItens")
                        .HasForeignKey("AtividadeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Escala", "Escala")
                        .WithMany("EscalaItens")
                        .HasForeignKey("EscalaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("EscalaItens")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Atividade");

                    b.Navigation("Escala");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Grupo", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "MinisterioPreferencial")
                        .WithMany("Grupos")
                        .HasForeignKey("MinisterioPreferencialId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MinisterioPreferencial");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.GrupoVoluntario", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Grupo", "Grupo")
                        .WithMany("GrupoVoluntarios")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("GrupoVoluntarios")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Grupo");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.RegistroAlteracao", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("RegistroAlteracoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.RegistroCriacao", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("RegistroCriacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.RegistroLogin", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("RegistroLogins")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.SituacaoAgendamento", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Agendamento", "Agendamento")
                        .WithOne("SituacaoAgendamento")
                        .HasForeignKey("SistemaNacoes.Domain.Entidades.SituacaoAgendamento", "AgendamentoId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Agendamento");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.UsuarioMinisterio", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("UsuariosMinisterios")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("UsuariosMinisterios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Ministerio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.VoluntarioMinisterio", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("VoluntarioMinisterios")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("VoluntarioMinisterios")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Ministerio");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Agenda", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Escalas");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Agendamento", b =>
                {
                    b.Navigation("AgendamentoAtividades");

                    b.Navigation("SituacaoAgendamento")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Atividade", b =>
                {
                    b.Navigation("AgendamentoAtividades");

                    b.Navigation("EscalaItens");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Escala", b =>
                {
                    b.Navigation("EscalaItens");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Grupo", b =>
                {
                    b.Navigation("GrupoVoluntarios");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Ministerio", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Atividades");

                    b.Navigation("Escalas");

                    b.Navigation("Grupos");

                    b.Navigation("UsuariosMinisterios");

                    b.Navigation("VoluntarioMinisterios");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Usuario", b =>
                {
                    b.Navigation("RegistroAlteracoes");

                    b.Navigation("RegistroCriacoes");

                    b.Navigation("RegistroLogins");

                    b.Navigation("UsuariosMinisterios");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Voluntario", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("DatasIndisponiveis");

                    b.Navigation("EscalaItens");

                    b.Navigation("GrupoVoluntarios");

                    b.Navigation("VoluntarioMinisterios");
                });
#pragma warning restore 612, 618
        }
    }
}
