using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class EscalaConfig : IEntityTypeConfiguration<Escala>
{
    public void Configure(EntityTypeBuilder<Escala> builder)
    {
        builder.ToTable("escalas");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.QuantidadeVoluntarios)
            .HasColumnType("INT")
            .HasColumnName("quantidade_voluntarios")
            .IsRequired();

        builder.Property(x => x.AgendaId)
            .HasColumnType("INT")
            .HasColumnName("agend_id")
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

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
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