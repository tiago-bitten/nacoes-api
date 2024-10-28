using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Entidades.AgendamentoAtividade;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class AgendamentoAtividadeConfig : EntidadeBaseConfig<AgendamentoAtividade>
{
    public override void Configure(EntityTypeBuilder<AgendamentoAtividade> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.AgendamentoId)
            .IsRequired();
        
        builder.Property(x => x.AtividadeId)
            .IsRequired();
        
        builder.HasOne(x => x.Agendamento)
            .WithMany(x => x.AgendamentoAtividades)
            .HasForeignKey(x => x.AgendamentoId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.Atividade)
            .WithMany(x => x.AgendamentoAtividades)
            .HasForeignKey(x => x.AtividadeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}