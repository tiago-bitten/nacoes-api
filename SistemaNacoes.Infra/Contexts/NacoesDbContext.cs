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
    public DbSet<Grupo> Grupos { get; set; }
    public DbSet<Ministerio> Ministerios { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<Agenda> Agendas { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<DataIndisponivel> DataIndisponiveis { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfig());
        modelBuilder.ApplyConfiguration(new VoluntarioConfig());
        modelBuilder.ApplyConfiguration(new VoluntarioMinisterioConfig());
        modelBuilder.ApplyConfiguration(new UsuarioMinisterioConfig());
        modelBuilder.ApplyConfiguration(new GrupoConfig());
        modelBuilder.ApplyConfiguration(new MinisterioConfig());
        modelBuilder.ApplyConfiguration(new AtividadeConfig());
        modelBuilder.ApplyConfiguration(new AgendaConfig());
        modelBuilder.ApplyConfiguration(new AgendamentoConfig());
        modelBuilder.ApplyConfiguration(new DataIndisponivelConfig());
        
        base.OnModelCreating(modelBuilder);
    }
}