using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class EscalaItemConfig : EntidadeBaseConfig<EscalaItem>
{
    public override void Configure(EntityTypeBuilder<EscalaItem> builder)
    {
        builder.Property(x => x.EscalaId)
            .IsRequired();
        
        builder.Property(x => x.VoluntarioId)
            .IsRequired();
        
        builder.Property(x => x.AtividadeId)
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