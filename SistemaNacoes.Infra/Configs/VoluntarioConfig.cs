using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Infra.Configs;

public class VoluntarioConfig : EntidadeBaseConfig<Voluntario>
{
    public override void Configure(EntityTypeBuilder<Voluntario> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasMaxLength(ConfigHelper.VarcharPadrao)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(ConfigHelper.VarcharPadrao);

        builder.Property(x => x.Cpf)
            .HasMaxLength(11);

        builder.Property(x => x.Celular)
            .HasMaxLength(15);
            
        builder.Property(x => x.ChaveAcesso)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.DataNascimento);
        
        builder.HasMany(x => x.GrupoVoluntarios)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);
            
        builder.HasMany(x => x.VoluntarioMinisterios)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Agendamentos)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.DataIndisponiveis)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.EscalaItens)
            .WithOne(x => x.Voluntario)
            .HasForeignKey(x => x.VoluntarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}