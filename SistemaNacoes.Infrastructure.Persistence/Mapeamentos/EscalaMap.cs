using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class EscalaMap : IEntityTypeConfiguration<Escala>
    {
        public void Configure(EntityTypeBuilder<Escala> builder)
        {
            builder.ToTable("escalas");

            builder.HasKey(e => e.Id)
                .HasName("id");

            builder.Property(e => e.QuantidadeVoluntarios)
                .HasColumnType("INT")
                .HasColumnName("quantidade_voluntarios")
                .IsRequired();

            builder.Property(e => e.AgendaId)
                .HasColumnType("INT")
                .HasColumnName("agenda_id")
                .IsRequired();

            builder.Property(e => e.MinisterioId)
                .HasColumnType("INT")
                .HasColumnName("ministerio_id")
                .IsRequired();

            builder.Property(e => e.Usada)
                .HasColumnType("BOOLEAN")
                .HasColumnName("usada")
                .IsRequired();

            builder.HasOne(e => e.Agenda)
                .WithMany(a => a.Escalas)
                .HasForeignKey(e => e.AgendaId);

            builder.HasOne(e => e.Ministerio)
                .WithMany(m => m.Escalas)
                .HasForeignKey(e => e.MinisterioId);
        }
    }
}
