using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class DataIndisponivelConfig : EntidadeBaseConfig<DataIndisponivel>
{
    private const string NomeTabela = "datas_indisponiveis";
    
    public DataIndisponivelConfig() : base(NomeTabela) { }
    
    public override void Configure(EntityTypeBuilder<DataIndisponivel> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.DataInicio)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("data_inicio")
            .IsRequired();
        
        builder.Property(x => x.DataFinal)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("data_final")
            .IsRequired();

        builder.Property(x => x.Motivo)
            .HasColumnType("VARCHAR(255)")
            .HasColumnName("motivo");

        builder.Property(x => x.VoluntarioId)
            .HasColumnType("INT")
            .HasColumnName("voluntario_id")
            .IsRequired();
        
        builder.Property(x => x.Suspenso)
            .HasColumnType("BOOLEAN")
            .HasColumnName("suspenso")
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.HasOne(x => x.Voluntario)
            .WithMany(x => x.DatasIndisponiveis)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}