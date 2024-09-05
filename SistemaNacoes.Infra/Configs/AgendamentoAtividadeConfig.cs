using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class AgendamentoAtividadeConfig : IEntityTypeConfiguration<AgendamentoAtividade>
{
    public void Configure(EntityTypeBuilder<AgendamentoAtividade> builder)
    {
        builder.ToTable("agendamentos_atividades");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.AgendamentoId)
            .HasColumnType("INT")
            .HasColumnName("agendamento_id")
            .IsRequired();
        
        builder.Property(x => x.AtividadeId)
            .HasColumnType("INT")
            .HasColumnName("atividade_id")
            .IsRequired();
        
        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
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