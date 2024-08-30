using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnName("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasColumnType("VARCHAR(11)")
            .HasColumnName("cpf");
        
        builder.Property(x => x.Celular)
            .HasColumnType("VARCHAR(15)")
            .HasColumnName("celular");

        builder.Property(x => x.DataNascimento)
            .HasColumnType("DATE")
            .HasColumnName("data_nascimento");

        builder.Property(x => x.Email)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("email")
            .IsRequired();

        builder.Property(x => x.SenhaHash)
            .HasColumnType("VARCHAR(900)")
            .HasColumnName("senha_hash")
            .IsRequired();
        
        builder.Property(x => x.Permissoes)
            .HasColumnType("BIGINT")
            .HasColumnName("permissoes")
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasMany(x => x.UsuariosMinisterios)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(x => x.RegistroLogins)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}