using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.PerfilAcesso;
using SistemaNacoes.Infra.Configs.Abstracoes;
using SistemaNacoes.Shared.Extensions;

namespace SistemaNacoes.Infra.Configs;

public class PerfilAcessoConfig : EntidadeBaseConfig<PerfilAcesso>
{
    public override void Configure(EntityTypeBuilder<PerfilAcesso> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(x => x.Permissoes)
            .HasEnumConversion()
            .IsRequired();

        builder.HasMany(x => x.Usuarios)
            .WithOne(x => x.PerfilAcesso)
            .HasForeignKey(x => x.PerfilAcessoId);
    }
}