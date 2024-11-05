using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Infra.Configs.Abstracoes;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Infra.Configs;

public class HistoricoEntidadeConfig : EntidadeBaseConfig<HistoricoEntidade>
{
    public override void Configure(EntityTypeBuilder<HistoricoEntidade> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Tabela)
            .IsRequired();

        builder.Property(x => x.ItemId)
            .IsRequired();

        builder.Property(x => x.UsuarioId);

        builder.Property(x => x.Ip)
            .HasMaxLength(ConfigHelper.VarcharPadrao)
            .IsRequired();

        builder.Property(x => x.UserAgent)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Data)
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.Historicos)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}