using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class MinisterioMap : IEntityTypeConfiguration<Ministerio>
    {
        public void Configure(EntityTypeBuilder<Ministerio> builder)
        {
            builder.ToTable("ministerios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("descricao");

            builder.Property(e => e.Cor)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("cor")
                .IsRequired();
        }
    }
}
