using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class DataIndisponivelMap : IEntityTypeConfiguration<DataIndisponivel>
    {
        public void Configure(EntityTypeBuilder<DataIndisponivel> builder)
        {
            builder.ToTable("datas_indisponiveis");

            builder.HasKey(e => e.Id)
                .HasName("id");

            builder.Property(e => e.DataInicio)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("data_inicio")
                .IsRequired();

            builder.Property(e => e.DataFinal)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("data_final")
                .IsRequired();

            builder.Property(e => e.VoluntarioId)
                .HasColumnType("INT")
                .HasColumnName("voluntario_id")
                .IsRequired();

            builder.HasOne(e => e.Voluntario)
                .WithMany(v => v.DatasIndisponiveis)
                .HasForeignKey(e => e.VoluntarioId);
        }
    }
}
