using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.UsuarioMinisterio;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class UsuarioMinisterioConfig : EntidadeBaseConfig<UsuarioMinisterio>
{
    public override void Configure(EntityTypeBuilder<UsuarioMinisterio> builder)
    {
        base.Configure(builder);   
        
        builder.Property(x => x.UsuarioId)
            .IsRequired();

        builder.Property(x => x.MinisterioId)
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.UsuariosMinisterios)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Ministerio)
            .WithMany(x => x.UsuariosMinisterios)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}