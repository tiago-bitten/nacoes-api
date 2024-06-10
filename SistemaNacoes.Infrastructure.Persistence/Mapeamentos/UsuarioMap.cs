using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {   
            builder.ToTable("usuarios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("nome")
                .IsRequired();
            
            builder.Property(e => e.Email)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("email")
                .IsRequired();

            builder.Property(e => e.Senha)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("senha")
                .IsRequired();

            builder.Property(e => e.Aprovado)
                .HasColumnType("BOOLEAN")
                .HasColumnName("aprovado")
                .IsRequired();

            builder.Property(e => e.Admin)
                .HasColumnType("BOOLEAN")
                .HasColumnName("admin")
                .IsRequired();
        }
    }
}
