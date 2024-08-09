using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class DataIndisponivelConfig : IEntityTypeConfiguration<DataIndisponivel>
{
    public void Configure(EntityTypeBuilder<DataIndisponivel> builder)
    {
        builder.ToTable("datas_indisponiveis");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
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