using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class MinisterioConfig : EntidadeBaseConfig<Ministerio>
{
    private const string NomeTabela = "ministerios";

    public MinisterioConfig() : base(NomeTabela) { }
    
    public override void Configure(EntityTypeBuilder<Ministerio> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();
        
        builder.Property(x => x.Descricao)
            .HasColumnType("VARCHAR(255)")
            .HasColumnName("descricao");

        builder.Property(x => x.Cor)
            .HasColumnType("VARCHAR(7)")
            .HasColumnName("cor")
            .IsRequired();

        builder.HasMany(x => x.Atividades)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.VoluntarioMinisterios)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.UsuariosMinisterios)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Agendamentos)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Escalas)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Grupos)
            .WithOne(x => x.MinisterioPreferencial)
            .HasForeignKey(x => x.MinisterioPreferencialId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}