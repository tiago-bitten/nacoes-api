using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class AgendaConfig : IEntityTypeConfiguration<Agenda>
{
    public void Configure(EntityTypeBuilder<Agenda> builder)
    {
        builder.ToTable("agendas");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Titulo)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("titulo")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("descricao");
        
        builder.Property(x => x.DataInicio)
            .HasColumnType("DATETIME")
            .HasColumnName("data_inicio")
            .IsRequired();

        builder.Property(x => x.DataFinal)
            .HasColumnType("DATETIME")
            .HasColumnName("data_final")
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnType("BOOLEAN")
            .HasColumnName("ativo")
            .HasDefaultValue(true)
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