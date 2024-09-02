using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class VoluntarioMinisterioConfig : IEntityTypeConfiguration<VoluntarioMinisterio>
{
    public void Configure(EntityTypeBuilder<VoluntarioMinisterio> builder)
    {
        builder.ToTable("voluntarios_ministerios");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.VoluntarioId)
            .HasColumnType("INT")
            .HasColumnName("voluntario_id")
            .IsRequired();

        builder.Property(x => x.MinisterioId)
            .HasColumnType("INT")
            .HasColumnName("ministerio_id")
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
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