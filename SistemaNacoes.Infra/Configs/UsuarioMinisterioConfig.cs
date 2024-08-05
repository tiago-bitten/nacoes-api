using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class UsuarioMinisterioConfig : IEntityTypeConfiguration<UsuarioMinisterio>
{
    public void Configure(EntityTypeBuilder<UsuarioMinisterio> builder)
    {
        builder.ToTable("usuarios_ministerios");
        
        builder.HasKey(x => new { x.UsuarioId, x.MinisterioId });
        
        builder.Property(x => x.UsuarioId)
            .HasColumnType("INT")
            .HasColumnName("usuario_id")
            .IsRequired();

        builder.Property(x => x.MinisterioId)
            .HasColumnType("INT")
            .HasColumnName("ministerio_id")
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnType("BOOLEAN")
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.UsuariosMinisterios)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Ministerio)
            .WithMany(x => x.UsuariosMinisterios)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}