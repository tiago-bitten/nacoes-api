using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class AtividadeMap : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("atividades");

            builder.HasKey(e => e.Id)
                .HasName("id");

            builder.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(e => e.MaximoVoluntarios)
                .HasColumnType("INT")
                .HasColumnName("maximo_voluntarios")
                .IsRequired();

            builder.Property(e => e.Ativo)
                .HasColumnType("BOOLEAN")
                .HasColumnName("ativo")
                .IsRequired();

            builder.Property(e => e.MinisterioId)
                .HasColumnType("INT")
                .HasColumnName("ministerio_id")
                .IsRequired();

            builder.HasOne(e => e.Ministerio)
                .WithMany(m => m.Atividades)
                .HasForeignKey(e => e.MinisterioId);
        }
    }
}
