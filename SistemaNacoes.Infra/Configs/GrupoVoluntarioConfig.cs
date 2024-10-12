using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class GrupoVoluntarioConfig : EntidadeBaseConfig<GrupoVoluntario>
{
    public override void Configure(EntityTypeBuilder<GrupoVoluntario> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.GrupoId)
            .HasColumnType("INT")
            .HasColumnName("grupo_id")
            .IsRequired();

        builder.Property(x => x.VoluntarioId)
            .HasColumnType("INT")
            .HasColumnName("voluntario_id")
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