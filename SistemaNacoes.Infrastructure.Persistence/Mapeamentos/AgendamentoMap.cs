using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("agendamentos");

            builder.HasKey(e => e.Id)
                .HasName("id");

            builder.Property(e => e.VoluntarioId)
                .HasColumnType("INT")
                .HasColumnName("voluntario_id")
                .IsRequired();

            builder.Property(e => e.MinisterioId)
                .HasColumnType("INT")
                .HasColumnName("ministerio_id")
                .IsRequired();

            builder.Property(e => e.AgendaId)
                .HasColumnType("INT")
                .HasColumnName("agenda_id")
                .IsRequired();

            builder.HasOne(e => e.Voluntario)
                .WithMany(v => v.Agendamentos)
                .HasForeignKey(e => e.VoluntarioId);

            builder.HasOne(e => e.Ministerio)
                .WithMany(m => m.Agendamentos)
                .HasForeignKey(e => e.MinisterioId);

            builder.HasOne(e => e.Agenda)
                .WithMany(a => a.Agendamentos)
                .HasForeignKey(e => e.AgendaId);
        }
    }
}
