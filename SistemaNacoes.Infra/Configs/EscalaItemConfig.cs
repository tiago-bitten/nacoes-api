using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class EscalaItemConfig : IEntityTypeConfiguration<EscalaItem>
{
    public void Configure(EntityTypeBuilder<EscalaItem> builder)
    {
        builder.ToTable("escalas_itens");
        
        builder.HasKey(x => new { x.EscalaId, x.VoluntarioId, x.AtividadeId });
        
        builder.Property(x => x.EscalaId)
            .HasColumnType("INT")
            .HasColumnName("escala_id")
            .IsRequired();
        
        builder.Property(x => x.VoluntarioId)
            .HasColumnType("INT")
            .HasColumnName("voluntario_id")
            .IsRequired();
        
        builder.Property(x => x.AtividadeId)
            .HasColumnType("INT")
            .HasColumnName("atividade_id")
            .IsRequired();
        
        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.HasOne(x => x.Escala)
            .WithMany(x => x.EscalaItens)
            .HasForeignKey(x => x.EscalaId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.Voluntario)
            .WithMany(x => x.EscalaItens)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.Atividade)
            .WithMany(x => x.EscalaItens)
            .HasForeignKey(x => x.AtividadeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}