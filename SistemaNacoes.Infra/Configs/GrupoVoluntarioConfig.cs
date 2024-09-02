using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class GrupoVoluntarioConfig : IEntityTypeConfiguration<GrupoVoluntario>
{
    public void Configure(EntityTypeBuilder<GrupoVoluntario> builder)
    {
        builder.ToTable("grupos_voluntarios");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.GrupoId)
            .HasColumnType("INT")
            .HasColumnName("grupo_id")
            .IsRequired();

        builder.Property(x => x.VoluntarioId)
            .HasColumnType("INT")
            .HasColumnName("voluntario_id")
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasOne(x => x.Grupo)
            .WithMany(x => x.GrupoVoluntarios)
            .HasForeignKey(x => x.GrupoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Voluntario)
            .WithMany(x => x.GrupoVoluntarios)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}