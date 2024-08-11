using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class SituacaoAgendamentoConfig : IEntityTypeConfiguration<SituacaoAgendamento>
{
    public void Configure(EntityTypeBuilder<SituacaoAgendamento> builder)
    {
        builder.ToTable("situacoes_agendamentos");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Ativo)
            .HasColumnType("BOOLEAN")
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("VARCHAR(250)")
            .HasColumnName("descricao");

        builder.Property(x => x.AgendamentoId)
            .HasColumnType("INT")
            .HasColumnName("agendamento_id")
            .IsRequired();

        builder.HasOne(x => x.Agendamento)
            .WithOne(x => x.SituacaoAgendamento)
            .HasForeignKey<SituacaoAgendamento>(x => x.AgendamentoId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}