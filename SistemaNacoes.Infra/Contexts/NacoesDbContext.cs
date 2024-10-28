using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Entidades.Agendamento;
using SistemaNacoes.Domain.Entidades.AgendamentoAtividade;
using SistemaNacoes.Domain.Entidades.Atividade;
using SistemaNacoes.Domain.Entidades.DataIndisponivel;
using SistemaNacoes.Domain.Entidades.Escala;
using SistemaNacoes.Domain.Entidades.EscalaItem;
using SistemaNacoes.Domain.Entidades.Grupo;
using SistemaNacoes.Domain.Entidades.GrupoVoluntario;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Infra.Configs;
using SistemaNacoes.Shared.Extensions;

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
    public DbSet<Escala> Escalas { get; set; }
    public DbSet<EscalaItem> EscalaItens { get; set; }
    public DbSet<AgendamentoAtividade> AgendamentoAtividades { get; set; }
    public DbSet<SituacaoAgendamento> SituacaoAgendamentos { get; set; }
    public DbSet<GrupoVoluntario> GrupoVoluntarios { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<HistoricoLogin> HistoricoLogins { get; set; }
    public DbSet<HistoricoEntidade> HistoricoEntidades { get; set; }
    
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
        modelBuilder.ApplyConfiguration(new EscalaConfig());
        modelBuilder.ApplyConfiguration(new EscalaItemConfig());
        modelBuilder.ApplyConfiguration(new AgendamentoAtividadeConfig());
        modelBuilder.ApplyConfiguration(new GrupoVoluntarioConfig());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfig());
        modelBuilder.ApplyConfiguration(new HistoricoLoginConfig());
        modelBuilder.ApplyConfiguration(new HistoricoEntidadeConfig());
        
        modelBuilder.AplicarNomenclaturaNacoes();
        
        base.OnModelCreating(modelBuilder);
    }
}