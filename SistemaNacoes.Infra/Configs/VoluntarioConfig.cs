﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class VoluntarioConfig : IEntityTypeConfiguration<Voluntario>
{
    public void Configure(EntityTypeBuilder<Voluntario> builder)
    {
        builder.ToTable("voluntarios");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("email")
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("cpf");

        builder.Property(x => x.ChaveAcesso)
            .HasColumnType("UUID")
            .HasColumnName("chave_acesso")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.DataNascimento)
            .HasColumnType("DATE")
            .HasColumnName("data_nascimento");

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.GrupoId)
            .HasColumnType("INT")
            .HasColumnName("grupo_id");

        builder.HasOne(x => x.Grupo)
            .WithMany(x => x.Voluntarios)
            .HasForeignKey(x => x.GrupoId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(x => x.VoluntariosMinisterios)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Agendamentos)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.DatasIndisponiveis)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.EscalaItens)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}