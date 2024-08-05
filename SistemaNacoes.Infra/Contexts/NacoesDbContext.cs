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
    public DbSet<Voluntario> Voluntarios { get; set; }
    public DbSet<VoluntarioMinisterio> VoluntarioMinisterios { get; set; }
    public DbSet<UsuarioMinisterio> UsuarioMinisterios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfig());
        modelBuilder.ApplyConfiguration(new VoluntarioConfig());
        modelBuilder.ApplyConfiguration(new VoluntarioMinisterioConfig());
        modelBuilder.ApplyConfiguration(new UsuarioMinisterioConfig());
        
        base.OnModelCreating(modelBuilder);
    }
}