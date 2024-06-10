using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("agendas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Titulo)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("titulo")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("descricao");

            builder.Property(e => e.DataInicio)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("data_inicio")
                .IsRequired();

            builder.Property(e => e.DataFinal)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("data_final")
                .IsRequired();

            builder.Property(e => e.Ativo)
                .HasColumnType("BOOLEAN")
                .HasColumnName("ativo")
                .IsRequired();
        }
    }
}
