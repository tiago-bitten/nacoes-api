using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class GrupoConfig : EntidadeBaseConfig<Grupo>
{
    public GrupoConfig() : base("grupos") { }
    
    public override void Configure(EntityTypeBuilder<Grupo> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.MinisterioPreferencialId)
            .HasColumnType("INT")
            .HasColumnName("ministerio_preferencial_id");

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasMany(x => x.GrupoVoluntarios)
            .WithOne(x => x.Grupo)
            .HasForeignKey(x => x.GrupoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.MinisterioPreferencial)
            .WithMany(x => x.Grupos)
            .HasForeignKey(x => x.MinisterioPreferencialId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}