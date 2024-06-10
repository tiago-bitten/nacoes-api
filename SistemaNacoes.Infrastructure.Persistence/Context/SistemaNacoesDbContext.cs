using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infrastructure.Persistence.Mapeamentos;

namespace SistemaNacoes.Infrastructure.Persistence.Data
{
    public class SistemaNacoesDbContext : DbContext
    {
        public SistemaNacoesDbContext(DbContextOptions<SistemaNacoesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Ministerio> Ministerios { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<VoluntarioMinisterio> VoluntariosMinisterios { get; set; }
        public DbSet<UsuarioMinisterio> UsuariosMinisterios { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Escala> Escalas { get; set; }
        public DbSet<EscalaItem> EscalaItens { get; set; }
        public DbSet<EscalaVoluntario> EscalasVoluntarios { get; set; }
        public DbSet<DataIndisponivel> DatasIndisponiveis { get; set; }
        public DbSet<Historico> Historicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VoluntarioMap());
            modelBuilder.ApplyConfiguration(new MinisterioMap());
            modelBuilder.ApplyConfiguration(new AtividadeMap());
            modelBuilder.ApplyConfiguration(new VoluntarioMinisterioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMinisterioMap());
            modelBuilder.ApplyConfiguration(new AgendaMap());
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new EscalaMap());
            modelBuilder.ApplyConfiguration(new EscalaItemMap());
            modelBuilder.ApplyConfiguration(new EscalaVoluntarioMap());
            modelBuilder.ApplyConfiguration(new DataIndisponivelMap());
            modelBuilder.ApplyConfiguration(new HistoricoMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sistema_nacoes;Username=postgres;Password=postgres",
                    x => x.MigrationsAssembly("SistemaNacoes.Infrastructure.Persistence"));
            }
        }
    }
}
