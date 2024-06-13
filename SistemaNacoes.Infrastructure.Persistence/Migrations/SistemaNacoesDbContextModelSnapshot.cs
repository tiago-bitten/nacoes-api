﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaNacoes.Infrastructure.Persistence.Data;

#nullable disable

namespace SistemaNacoes.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(SistemaNacoesDbContext))]
    partial class SistemaNacoesDbContextModelSnapshot : ModelSnapshot
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

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .HasColumnType("BOOLEAN")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("data_final");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("data_inicio");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("descricao");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.ToTable("agendas", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgendaId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("agenda_id");

                    b.Property<int?>("MinisterioId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_id");

                    b.Property<int?>("VoluntarioId")
                        .IsRequired()
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

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .HasColumnType("BOOLEAN")
                        .HasColumnName("ativo");

                    b.Property<int>("MaximoVoluntarios")
                        .HasColumnType("INT")
                        .HasColumnName("maximo_voluntarios");

                    b.Property<int?>("MinisterioId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

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

                    b.Property<int?>("VoluntarioId")
                        .IsRequired()
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
                        .HasColumnName("agenda_id");

                    b.Property<int?>("AgendaId1")
                        .HasColumnType("INT");

                    b.Property<int>("MinisterioId")
                        .HasColumnType("INT")
                        .HasColumnName("ministerio_id");

                    b.Property<int?>("MinisterioId1")
                        .HasColumnType("INT");

                    b.Property<int>("QuantidadeVoluntarios")
                        .HasColumnType("INT")
                        .HasColumnName("quantidade_voluntarios");

                    b.Property<bool?>("Usada")
                        .HasColumnType("boolean")
                        .HasColumnName("usada");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("AgendaId1");

                    b.HasIndex("MinisterioId");

                    b.HasIndex("MinisterioId1");

                    b.ToTable("escalas", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.EscalaItem", b =>
                {
                    b.Property<int>("EscalaId")
                        .HasColumnType("INT")
                        .HasColumnName("escala_id");

                    b.Property<int>("AtividadeId")
                        .HasColumnType("INT")
                        .HasColumnName("atividade_id");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("INT")
                        .HasColumnName("voluntario_id");

                    b.Property<int>("QuantidadeVoluntarios")
                        .HasColumnType("INT")
                        .HasColumnName("quantidade_voluntarios");

                    b.HasKey("EscalaId", "AtividadeId", "VoluntarioId");

                    b.HasIndex("AtividadeId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("escala_itens", (string)null);
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
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("MinisterioPreferencialId");

                    b.ToTable("grupos", (string)null);
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Historico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AlteradoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("alterado_em")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("DadosAnteriores")
                        .HasColumnType("JSONB")
                        .HasColumnName("dados_anteriores");

                    b.Property<string>("DadosNovos")
                        .HasColumnType("JSONB")
                        .HasColumnName("dados_novos");

                    b.Property<string>("Operacao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("operacao");

                    b.Property<int>("RegistroId")
                        .HasColumnType("INT")
                        .HasColumnName("registro_id");

                    b.Property<string>("Tabela")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("tabela");

                    b.Property<int?>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("historicos", (string)null);
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
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("cor");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

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

                    b.Property<bool?>("Admin")
                        .IsRequired()
                        .HasColumnType("BOOLEAN")
                        .HasColumnName("admin");

                    b.Property<bool?>("Aprovado")
                        .IsRequired()
                        .HasColumnType("BOOLEAN")
                        .HasColumnName("aprovado");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("senha");

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

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .HasColumnType("BOOLEAN")
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

                    b.Property<Guid>("AccessKey")
                        .HasColumnType("UUID")
                        .HasColumnName("access_key");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("data_nascimento");

                    b.Property<int?>("GrupoId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("grupo_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

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

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .HasColumnType("BOOLEAN")
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("Agendamentos")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Cascade)
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ministerio");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.DataIndisponivel", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("DatasIndisponiveis")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Escala", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Agenda", "Agenda")
                        .WithMany()
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Agenda", null)
                        .WithMany("Escalas")
                        .HasForeignKey("AgendaId1");

                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany()
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", null)
                        .WithMany("Escalas")
                        .HasForeignKey("MinisterioId1");

                    b.Navigation("Agenda");

                    b.Navigation("Ministerio");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.EscalaItem", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Atividade", "Atividade")
                        .WithMany("EscalaItens")
                        .HasForeignKey("AtividadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Escala", "Escala")
                        .WithMany("EscalaItens")
                        .HasForeignKey("EscalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("EscalaItens")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Restrict)
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MinisterioPreferencial");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Historico", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Historicos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.UsuarioMinisterio", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("UsuariosMinisterios")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("UsuariosMinisterios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ministerio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.Voluntario", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Grupo", "Grupo")
                        .WithMany("Voluntarios")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("SistemaNacoes.Domain.Entidades.VoluntarioMinisterio", b =>
                {
                    b.HasOne("SistemaNacoes.Domain.Entidades.Ministerio", "Ministerio")
                        .WithMany("VoluntariosMinisterios")
                        .HasForeignKey("MinisterioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaNacoes.Domain.Entidades.Voluntario", "Voluntario")
                        .WithMany("VoluntariosMinisterios")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Cascade)
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
                    b.Navigation("Historicos");

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
