﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class UsuarioMinisterioMap : IEntityTypeConfiguration<UsuarioMinisterio>
    {
        public void Configure(EntityTypeBuilder<UsuarioMinisterio> builder)
        {
            builder.ToTable("usuarios_ministerios");

            builder.HasKey(e => new { e.UsuarioId, e.MinisterioId });

            builder.Property(e => e.UsuarioId)
                .HasColumnName("usuario_id");

            builder.Property(e => e.MinisterioId)
                .HasColumnName("ministerio_id");

            builder.Property(e => e.Ativo)
                .HasColumnType("BOOLEAN")
                .HasColumnName("ativo")
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithMany(u => u.UsuariosMinisterios)
                .HasForeignKey(e => e.UsuarioId);

            builder.HasOne(e => e.Ministerio)
                .WithMany(m => m.UsuariosMinisterios)
                .HasForeignKey(e => e.MinisterioId);
        }
    }
}
