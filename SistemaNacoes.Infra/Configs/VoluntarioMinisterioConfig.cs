using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class VoluntarioMinisterioConfig : IEntityTypeConfiguration<VoluntarioMinisterio>
{
    public void Configure(EntityTypeBuilder<VoluntarioMinisterio> builder)
    {
        builder.ToTable("voluntarios_ministerios");
        
        builder.HasKey(x => new { x.VoluntarioId, x.MinisterioId });
        
        builder.Property(x => x.VoluntarioId)
            .HasColumnType("INT")
            .HasColumnName("voluntario_id")
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

        builder.HasOne(x => x.Voluntario)
            .WithMany(x => x.VoluntarioMinisterios)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Ministerio)
            .WithMany(x => x.VoluntarioMinisterios)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}