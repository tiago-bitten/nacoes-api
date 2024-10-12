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
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.DataCriacao)
            .HasColumnType("TIMESTAMP WITH TIME ZONE")
            .HasColumnName("data_criacao")
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();
    }
}