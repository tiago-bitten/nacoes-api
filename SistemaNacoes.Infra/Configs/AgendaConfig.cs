using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Infra.Configs.Abstracoes;
using SistemaNacoes.Shared.Extensions;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Infra.Configs;

public class AgendaConfig : EntidadeBaseConfig<Agenda>
{
    public override void Configure(EntityTypeBuilder<Agenda> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Titulo)
            .HasMaxLength(ConfigHelper.VarcharPadrao)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasMaxLength(ConfigHelper.VarcharPadrao);
            
        builder.Property(x => x.DataInicio)
            .IsRequired();

        builder.Property(x => x.DataFinal)
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.Property(x => x.Status)
            .HasEnumConversion()
            .IsRequired();

        builder.HasMany(x => x.Agendamentos)
            .WithOne(x => x.Agenda)
            .HasForeignKey(x => x.AgendaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Escalas)
            .WithOne(x => x.Agenda)
            .HasForeignKey(x => x.AgendaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}