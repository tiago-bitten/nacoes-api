using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class VoluntarioMap : IEntityTypeConfiguration<Voluntario>
    {
        public void Configure(EntityTypeBuilder<Voluntario> builder)
        {
            builder.ToTable("voluntarios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.AccessKey)
                .HasColumnType("UUID")
                .HasColumnName("access_key")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(e => e.Cpf)
                .HasColumnType("VARCHAR(11)")
                .HasColumnName("cpf");

            builder.Property(e => e.DataNascimento)
                .HasColumnType("DATE")
                .HasColumnName("data_nascimento");

            builder.Property(e => e.GrupoId)
                .HasColumnName("grupo_id")
                .IsRequired();

            builder.HasOne(e => e.Grupo)
                .WithMany(g => g.Voluntarios)
                .HasForeignKey(e => e.GrupoId);
        }
    }
}
