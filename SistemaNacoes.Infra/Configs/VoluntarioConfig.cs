using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class VoluntarioConfig : EntidadeBaseConfig<Voluntario>
{
    private const string NomeTabela = "voluntarios";
    
    public VoluntarioConfig() : base(NomeTabela) { }
    
    public override void Configure(EntityTypeBuilder<Voluntario> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("email");

        builder.Property(x => x.Cpf)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("cpf");
        
        builder.Property(x => x.Celular)
            .HasColumnType("VARCHAR(15)")
            .HasColumnName("celular");

        builder.Property(x => x.ChaveAcesso)
            .HasColumnType("UUID")
            .HasColumnName("chave_acesso")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.DataNascimento)
            .HasColumnType("DATE")
            .HasColumnName("data_nascimento");

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