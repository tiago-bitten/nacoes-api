using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class EscalaConfig : EntidadeBaseConfig<Escala>
{
    private const string NomeTabela = "escalas";
    
    public EscalaConfig() : base(NomeTabela) { }
    
    public override void Configure(EntityTypeBuilder<Escala> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.QuantidadeVoluntarios)
            .HasColumnType("INT")
            .HasColumnName("quantidade_voluntarios")
            .IsRequired();

        builder.Property(x => x.AgendaId)
            .HasColumnType("INT")
            .HasColumnName("agenda_id")
            .IsRequired();
        
        builder.Property(x => x.MinisterioId)
            .HasColumnType("INT")
            .HasColumnName("ministerio_id")
            .IsRequired();

        builder.Property(x => x.Usada)
            .HasColumnType("BOOLEAN")
            .HasColumnName("usada")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasOne(x => x.Agenda)
            .WithMany(x => x.Escalas)
            .HasForeignKey(x => x.AgendaId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.Ministerio)
            .WithMany(x => x.Escalas)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(x => x.EscalaItens)
            .WithOne(x => x.Escala)
            .HasForeignKey(x => x.EscalaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}