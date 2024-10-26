using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class DataIndisponivelConfig : EntidadeBaseConfig<DataIndisponivel>
{
    public override void Configure(EntityTypeBuilder<DataIndisponivel> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.DataInicio)
            .IsRequired();
        
        builder.Property(x => x.DataFinal)
            .IsRequired();

        builder.Property(x => x.Motivo);

        builder.Property(x => x.VoluntarioId)
            .IsRequired();
        
        builder.Property(x => x.Suspenso)
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.HasOne(x => x.Voluntario)
            .WithMany(x => x.DataIndisponiveis)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}