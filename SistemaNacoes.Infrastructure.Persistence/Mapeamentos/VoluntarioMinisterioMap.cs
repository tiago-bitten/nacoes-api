using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class VoluntarioMinisterioMap : IEntityTypeConfiguration<VoluntarioMinisterio>
    {
        public void Configure(EntityTypeBuilder<VoluntarioMinisterio> builder)
        {
            builder.ToTable("voluntarios_ministerios");

            builder.HasKey(e => new { e.VoluntarioId, e.MinisterioId });

            builder.Property(e => e.VoluntarioId)
                .HasColumnType("INT")
                .HasColumnName("voluntario_id")
                .IsRequired();

            builder.Property(e => e.MinisterioId)
                .HasColumnType("INT")
                .HasColumnName("ministerio_id")
                .IsRequired();

            builder.Property(e => e.Ativo)
                .HasColumnType("BOOLEAN")
                .HasColumnName("ativo")
                .IsRequired();

            builder.HasOne(e => e.Voluntario)
                .WithMany(v => v.VoluntariosMinisterios)
                .HasForeignKey(e => e.VoluntarioId);

            builder.HasOne(e => e.Ministerio)
                .WithMany(m => m.VoluntariosMinisterios)
                .HasForeignKey(e => e.MinisterioId);
        }
    }
}
