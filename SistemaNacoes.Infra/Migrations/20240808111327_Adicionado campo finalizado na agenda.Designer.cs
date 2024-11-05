﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaNacoes.Infra.Contexts;

#nullable disable

namespace SistemaNacoes.Infra.Migrations
{
    [DbContext(typeof(NacoesDbContext))]
    [Migration("20240808111327_Adicionado campo finalizado na agenda")]
    partial class Adicionadocampofinalizadonaagenda
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MaximoVoluntarios")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
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

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

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
                        .IsRequired()
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
                        .HasColumnType("text");

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

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<bool>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.Property<string>("Senha")
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
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("email");

                    b.Property<int?>("GrupoId")
                        .HasColumnType("INT")
                        .HasColumnName("grupo_id");

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

                    b.HasIndex("GrupoId");

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
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("MinisterioPreferencial");
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

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Voluntario", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Grupo", "Grupo")
                        .WithMany("Voluntarios")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.VoluntarioMinisterio", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("VoluntariosMinisterios")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("VoluntariosMinisterios")
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

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Atividade", b =>
                {
                    b.Navigation("EscalaItens");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Escala", b =>
                {
                    b.Navigation("EscalaItens");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Grupo", b =>
                {
                    b.Navigation("Voluntarios");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Ministerio", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Atividades");

                    b.Navigation("Escalas");

                    b.Navigation("Grupos");

                    b.Navigation("UsuariosMinisterios");

                    b.Navigation("VoluntariosMinisterios");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Usuario", b =>
                {
                    b.Navigation("UsuariosMinisterios");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Voluntario", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("DatasIndisponiveis");

                    b.Navigation("EscalaItens");

                    b.Navigation("VoluntariosMinisterios");
                });
#pragma warning restore 612, 618
        }
    }
}
