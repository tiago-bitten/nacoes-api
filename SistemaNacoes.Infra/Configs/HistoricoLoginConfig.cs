using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Shared.Extensions;
using SistemaNacoes.Infra.Configs.Abstracoes;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Infra.Configs;

public class HistoricoLoginConfig : EntidadeBaseConfig<HistoricoLogin>
{
    public override void Configure(EntityTypeBuilder<HistoricoLogin> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.UsuarioId);

        builder.Property(x => x.Ip)
            .HasMaxLength(ConfigHelper.VarcharPadrao)
            .IsRequired();

        builder.Property(x => x.UserAgent)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Sucesso)
            .IsRequired();

        builder.Property(x => x.Motivo)
            .HasEnumConversion();
            
        builder.Property(x => x.DataAcesso)
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.RegistroLogins)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}