using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class AgendamentoConfig : EntidadeBaseConfig<Agendamento>
{
    private const string NomeTabela = "agendamentos";
    
    public AgendamentoConfig() : base(NomeTabela) { }
    
    public override void Configure(EntityTypeBuilder<Agendamento> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.VoluntarioId)
            .HasColumnType("INT")
            .HasColumnName("voluntario_id")
            .IsRequired();
        
        builder.Property(x => x.MinisterioId)
            .HasColumnType("INT")
            .HasColumnName("ministerio_id")
            .IsRequired();
        
        builder.Property(x => x.AgendaId)
            .HasColumnType("INT")
            .HasColumnName("agenda_id")
            .IsRequired();
        
        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.HasOne(x => x.Voluntario)
            .WithMany(x => x.Agendamentos)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.Ministerio)
            .WithMany(x => x.Agendamentos)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.Agenda)
            .WithMany(x => x.Agendamentos)
            .HasForeignKey(x => x.AgendaId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(x => x.AgendamentoAtividades)
            .WithOne(x => x.Agendamento)
            .HasForeignKey(x => x.AgendamentoId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.SituacaoAgendamento)
            .WithOne(x => x.Agendamento)
            .HasForeignKey<SituacaoAgendamento>(x => x.AgendamentoId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}