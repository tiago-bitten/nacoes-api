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

            builder.HasKey(e => new { e.EscalaId, e.AtividadeId });

            builder.Property(e => e.EscalaId)
                .HasColumnType("INT")
                .HasColumnName("escala_id")
                .IsRequired();

            builder.Property(e => e.AtividadeId)
                .HasColumnType("INT")
                .HasColumnName("atividade_id")
                .IsRequired();

            builder.Property(e => e.QuantidadeVoluntarios)
                .HasColumnType("INT")
                .HasColumnName("quantidade_voluntarios")
                .IsRequired();

            builder.HasOne(e => e.Escala)
                .WithMany(e => e.EscalaItens)
                .HasForeignKey(e => e.EscalaId);

            builder.HasOne(e => e.Atividade)
                .WithMany(a => a.EscalaItens)
                .HasForeignKey(e => e.AtividadeId);
        }
    }
}
