using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class AtividadeConfig : EntidadeBaseConfig<Atividade>
{
    public override void Configure(EntityTypeBuilder<Atividade> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.MaximoVoluntarios)
            .HasColumnType("INT")
            .HasColumnName("maximo_voluntarios")
            .IsRequired();

        builder.Property(x => x.MinisterioId)
            .HasColumnType("INT")
            .HasColumnName("ministerio_id")
            .IsRequired();

        builder.HasOne(x => x.Ministerio)
            .WithMany(x => x.Atividades)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.EscalaItens)
            .WithOne(x => x.Atividade)
            .HasForeignKey(x => x.AtividadeId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(x => x.AgendamentoAtividades)
            .WithOne(x => x.Atividade)
            .HasForeignKey(x => x.AtividadeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}