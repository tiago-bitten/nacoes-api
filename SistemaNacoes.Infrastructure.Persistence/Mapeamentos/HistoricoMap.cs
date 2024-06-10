using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Infrastructure.Persistence.Mapeamentos
{
    public class HistoricoMap : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.ToTable("historicos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Tabela)
                .HasColumnType("TEXT")
                .HasColumnName("tabela")
                .IsRequired();

            builder.Property(e => e.Operacao)
                .HasColumnType("TEXT")
                .HasColumnName("operacao")
                .IsRequired();

            builder.Property(e => e.RegistroId)
                .HasColumnType("INT")
                .HasColumnName("registro_id")
                .IsRequired();

            builder.Property(e => e.DadosAnteriores)
                .HasColumnType("JSONB")
                .HasColumnName("dados_anteriores")
                .IsRequired(false);

            builder.Property(e => e.DadosNovos)
                .HasColumnType("JSONB")
                .HasColumnName("dados_novos")
                .IsRequired(false);

            builder.Property(e => e.AlteradoEm)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("alterado_em")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.UsuarioId)
                .HasColumnType("INT")
                .HasColumnName("usuario_id")
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithMany(u => u.Historicos)
                .HasForeignKey(e => e.UsuarioId);
        }
    }
}
