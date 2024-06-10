using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("grupos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(e => e.MinisterioPreferencialId)
                .HasColumnType("INT")
                .HasColumnName("ministerio_preferencial_id")
                .IsRequired();

            builder.HasOne(e => e.MinisterioPreferencial)
                .WithMany(m => m.Grupos)
                .HasForeignKey(e => e.MinisterioPreferencialId);
        }
    }
}
