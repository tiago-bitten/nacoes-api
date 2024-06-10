using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class EscalaVoluntarioMap : IEntityTypeConfiguration<EscalaVoluntario>
    {
        public void Configure(EntityTypeBuilder<EscalaVoluntario> builder)
        {
            builder.ToTable("escalas_voluntarios");

            builder.HasKey(e => new { e.EscalaId, e.AtividadeId, e.VoluntarioId });

            builder.Property(e => e.EscalaId)
                .HasColumnType("INT")
                .HasColumnName("escala_id")
                .IsRequired();

            builder.Property(e => e.AtividadeId)
                .HasColumnType("INT")
                .HasColumnName("atividade_id")
                .IsRequired();

            builder.Property(e => e.VoluntarioId)
                .HasColumnType("INT")
                .HasColumnName("voluntario_id")
                .IsRequired();

            builder.HasOne(e => e.Escala)
                .WithMany(e => e.EscalasVoluntarios)
                .HasForeignKey(e => e.EscalaId);

            builder.HasOne(e => e.Atividade)
                .WithMany(a => a.EscalasVoluntarios)
                .HasForeignKey(e => e.AtividadeId);

            builder.HasOne(e => e.Voluntario)
                .WithMany(v => v.EscalasVoluntarios)
                .HasForeignKey(e => e.VoluntarioId);
        }
    }
}
