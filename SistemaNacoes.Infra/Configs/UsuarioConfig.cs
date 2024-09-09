using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class UsuarioConfig : EntidadeBaseConfig<Usuario>
{
    private const string NomeTabela = "usuarios";
    
    public UsuarioConfig() : base(NomeTabela) { }
    
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        base.Configure(builder);

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