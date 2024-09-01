using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class RegistroCriacaoConfig : IEntityTypeConfiguration<RegistroCriacao>
{
    public void Configure(EntityTypeBuilder<RegistroCriacao> builder)
    {
        builder.ToTable("registros_criacoes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.UsuarioId)
            .HasColumnType("INT")
            .HasColumnName("usuario_id");

        builder.Property(x => x.Ip)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("ip")
            .IsRequired();

        builder.Property(x => x.UserAgent)
            .HasColumnType("VARCHAR(500)")
            .HasColumnName("user_agent")
            .IsRequired();

        builder.Property(x => x.Data)
            .HasColumnType("TIMESTAMP WITH TIME ZONE")
            .HasColumnName("data")
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.RegistroCriacoes)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}