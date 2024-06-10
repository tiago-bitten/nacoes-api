using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class EscalaItemMap : IEntityTypeConfiguration<EscalaItem>
    {
        public void Configure(EntityTypeBuilder<EscalaItem> builder)
        {
            builder.ToTable("escala_itens");

            builder.HasKey(ei => new { ei.EscalaId, ei.AtividadeId, ei.VoluntarioId });

            builder.Property(ei => ei.EscalaId)
                .HasColumnType("INT")
                .HasColumnName("escala_id")
                .IsRequired();

            builder.Property(ei => ei.AtividadeId)
                .HasColumnType("INT")
                .HasColumnName("atividade_id")
                .IsRequired();

            builder.Property(ei => ei.VoluntarioId)
                .HasColumnType("INT")
                .HasColumnName("voluntario_id")
                .IsRequired();

            builder.Property(ei => ei.QuantidadeVoluntarios)
                .HasColumnType("INT")
                .HasColumnName("quantidade_voluntarios")
                .IsRequired();

            builder.HasOne(ei => ei.Escala)
                .WithMany(e => e.EscalaItens)
                .HasForeignKey(ei => ei.EscalaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ei => ei.Atividade)
                .WithMany(a => a.EscalaItens)
                .HasForeignKey(ei => ei.AtividadeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ei => ei.Voluntario)
                .WithMany(v => v.EscalaItens)
                .HasForeignKey(ei => ei.VoluntarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
