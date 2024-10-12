using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class RegistroAlteracaoConfig : EntidadeBaseConfig<RegistroAlteracao>
{
    public override void Configure(EntityTypeBuilder<RegistroAlteracao> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Tabela)
            .HasColumnType("TEXT")
            .HasColumnName("tabela")
            .IsRequired();

        builder.Property(x => x.ItemId)
            .HasColumnType("INT")
            .HasColumnName("item_id")
            .IsRequired();

        builder.Property(x => x.DadosAntigos)
            .HasColumnType("JSONB")
            .HasColumnName("dados_antigos")
            .IsRequired();

        builder.Property(x => x.DadosNovos)
            .HasColumnType("JSONB")
            .HasColumnName("dados_novos")
            .IsRequired();

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

        builder.Property(x => x.Data)
            .HasColumnType("TIMESTAMP WITH TIME ZONE")
            .HasColumnName("data")
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.RegistroAlteracoes)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}