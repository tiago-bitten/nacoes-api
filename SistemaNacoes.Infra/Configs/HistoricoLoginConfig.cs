using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class HistoricoLoginConfig : EntidadeBaseConfig<HistoricoLogin>
{
    public override void Configure(EntityTypeBuilder<HistoricoLogin> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.UsuarioId)
            .HasColumnType("INT")
            .HasColumnName("usuario_id");

        builder.Property(x => x.Ip)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("ip")
            .IsRequired();

        builder.Property(x => x.UserAgent)
            .HasColumnType("VARCHAR(500)")
            .HasColumnName("user_agent")
            .IsRequired();

        builder.Property(x => x.Sucesso)
            .HasColumnType("BOOLEAN")
            .HasColumnName("sucesso")
            .IsRequired();

        builder.Property(x => x.Motivo)
            .HasColumnType("TEXT")
            .HasColumnName("motivo")
            .HasConversion(x =>
                x.ToString(), x => (EMotivoLoginAcessoNegado)Enum.Parse(typeof(EMotivoLoginAcessoNegado),
                x));
        
        builder.Property(x => x.DataAcesso)
            .HasColumnType("TIMESTAMP WITH TIME ZONE")
            .HasColumnName("data")
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.RegistroLogins)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}