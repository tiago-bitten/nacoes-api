using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infra.Configs;

public class MinisterioConfig : IEntityTypeConfiguration<Ministerio>
{
    public void Configure(EntityTypeBuilder<Ministerio> builder)
    {
        builder.ToTable("ministerios");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.Cor)
            .HasColumnType("VARCHAR(7)")
            .HasColumnName("cor")
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasMany(x => x.Atividades)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.VoluntariosMinisterios)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.UsuariosMinisterios)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Agendamentos)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Escalas)
            .WithOne(x => x.Ministerio)
            .HasForeignKey(x => x.MinisterioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Grupos)
            .WithOne(x => x.MinisterioPreferencial)
            .HasForeignKey(x => x.MinisterioPreferencialId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Navigation(x => x.VoluntariosMinisterios)
            .AutoInclude();
    }
}