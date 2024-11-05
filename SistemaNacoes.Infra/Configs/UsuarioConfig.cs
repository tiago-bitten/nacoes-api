using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Usuario;
using SistemaNacoes.Infra.Configs.Abstracoes;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Infra.Configs;

public class UsuarioConfig : EntidadeBaseConfig<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasMaxLength(ConfigHelper.VarcharPadrao)
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasMaxLength(11);

        builder.Property(x => x.Celular)
            .HasMaxLength(15);

        builder.Property(x => x.DataNascimento);

        builder.Property(x => x.Email)
            .HasMaxLength(ConfigHelper.VarcharPadrao)
            .IsRequired();

        builder.Property(x => x.SenhaHash)
            .HasMaxLength(900)
            .IsRequired();

        builder.HasMany(x => x.UsuariosMinisterios)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.PerfilAcesso)
            .WithMany(x => x.Usuarios)
            .HasForeignKey(x => x.PerfilAcessoId);
    }
}