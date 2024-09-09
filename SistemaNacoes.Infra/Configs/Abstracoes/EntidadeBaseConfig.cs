using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Infra.Configs.Abstracoes;

public class EntidadeBaseConfig<T> : IEntityTypeConfiguration<T> where T : EntidadeBase
{
    private readonly string _nomeTabela; 
    
    public EntidadeBaseConfig(string nomeTabela)
    {
        _nomeTabela = nomeTabela;
    }
    
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(_nomeTabela);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
    }
}