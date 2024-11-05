using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.VoluntarioMinisterio;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class VoluntarioMinisterioConfig : EntidadeBaseConfig<VoluntarioMinisterio>
{
    public override void Configure(EntityTypeBuilder<VoluntarioMinisterio> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.VoluntarioId)
            .IsRequired();

        builder.Property(x => x.MinisterioId)
            .IsRequired();

        builder.HasOne(x => x.Voluntario)
            .WithMany(x => x.VoluntarioMinisterios)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Ministerio)
            .WithMany(x => x.VoluntarioMinisterios)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}