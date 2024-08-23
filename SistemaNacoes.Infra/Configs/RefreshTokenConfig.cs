using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.Token)
            .HasColumnType("text")
            .HasColumnName("token")
            .IsRequired();

        builder.Property(x => x.Principal)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("principal")
            .IsRequired();

        builder.Property(x => x.Revogado)
            .HasColumnType("BOOLEAN")
            .HasColumnName("revogado")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.DataExpiracao)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("data_expiracao")
            .IsRequired();
    }
}