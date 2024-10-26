using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Infra.Configs;

public class MinisterioConfig : EntidadeBaseConfig<Ministerio>
{
    public override void Configure(EntityTypeBuilder<Ministerio> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Nome)
            .HasMaxLength(ConfigHelper.VarcharPadrao)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasMaxLength(ConfigHelper.VarcharPadrao);
            
        builder.Property(x => x.Cor)
            .HasMaxLength(7)
            .IsRequired();

        builder.HasMany(x => x.Atividades)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.VoluntarioMinisterios)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.UsuariosMinisterios)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Agendamentos)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Escalas)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Grupos)
            .WithOne(x => x.MinisterioPreferencial)
            .HasForeignKey(x => x.MinisterioPreferencialId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}