using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs;

namespace SistemaNacoes.Infra.Contexts;

public class NacoesDbContext : DbContext
{
    public NacoesDbContext(DbContextOptions<NacoesDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfig());
        
        base.OnModelCreating(modelBuilder);
    }
}