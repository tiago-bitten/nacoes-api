using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class GrupoConfig : IEntityTypeConfiguration<Grupo>
{
    public void Configure(EntityTypeBuilder<Grupo> builder)
    {
        builder.ToTable("grupos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.MinisterioPreferencialId)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("ministerio_preferencial_id")
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasMany(x => x.Voluntarios)
            .WithOne(x => x.Grupo)
            .HasForeignKey(x => x.GrupoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.MinisterioPreferencial)
            .WithMany(x => x.Grupos)
            .HasForeignKey(x => x.MinisterioPreferencialId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}