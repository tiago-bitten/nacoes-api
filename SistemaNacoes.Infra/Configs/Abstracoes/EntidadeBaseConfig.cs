using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Infra.Configs.Abstracoes;

public class EntidadeBaseConfig<T> : IEntityTypeConfiguration<T> where T : EntidadeBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.DataCriacao)
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasDefaultValue(false)
            .IsRequired();
    }
}