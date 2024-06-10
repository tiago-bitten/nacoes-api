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

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id")
                .IsRequired();

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
                .HasColumnName("usada");

            builder.HasOne(e => e.Agenda)
                .WithMany()
                .HasForeignKey(e => e.AgendaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Ministerio)
                .WithMany()
                .HasForeignKey(e => e.MinisterioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.EscalaItens)
                .WithOne(ei => ei.Escala)
                .HasForeignKey(ei => ei.EscalaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
