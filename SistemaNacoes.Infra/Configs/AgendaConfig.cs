using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class AgendaConfig : EntidadeBaseConfig<Agenda>
{
    public override void Configure(EntityTypeBuilder<Agenda> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Titulo)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("titulo")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("descricao");
        
        builder.Property(x => x.DataInicio)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("data_inicio")
            .IsRequired();

        builder.Property(x => x.DataFinal)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("data_final")
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();
        
        builder.Property(x => x.Finalizado)
            .HasColumnType("BOOLEAN")
            .HasColumnName("finalizado")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasMany(x => x.Agendamentos)
            .WithOne(x => x.Agenda)
            .HasForeignKey(x => x.AgendaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Escalas)
            .WithOne(x => x.Agenda)
            .HasForeignKey(x => x.AgendaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}