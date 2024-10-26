using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class EscalaConfig : EntidadeBaseConfig<Escala>
{
    public override void Configure(EntityTypeBuilder<Escala> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.QuantidadeVoluntarios)
            .IsRequired();

        builder.Property(x => x.AgendaId)
            .IsRequired();
        
        builder.Property(x => x.MinisterioId)
            .IsRequired();

        builder.Property(x => x.Usada)
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasOne(x => x.Agenda)
            .WithMany(x => x.Escalas)
            .HasForeignKey(x => x.AgendaId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.Ministerio)
            .WithMany(x => x.Escalas)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(x => x.EscalaItens)
            .WithOne(x => x.Escala)
            .HasForeignKey(x => x.EscalaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}