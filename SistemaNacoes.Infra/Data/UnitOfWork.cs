using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;
using System;
using System.Threading.Tasks;
using SistemaNacoes.Domain.Interfaces;

namespace SistemaNacoes.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NacoesDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(
            NacoesDbContext context,
            IVoluntarioRepository voluntarioRepository,
            IGrupoRepository grupoRepository,
            IUsuarioRepository usuarioRepository,
            IUsuarioMinisterioRepository usuarioMinisterioRepository,
            IAgendamentoRepository agendamentoRepository,
            IMinisterioRepository ministerioRepository,
            IAgendaRepository agendaRepository,
            IAtividadeRepository atividadeRepository,
            IDataIndisponivelRepository dataIndisponivelRepository,
            IEscalaRepository escalaRepository,
            IEscalaItemRepository escalaItemRepository,
            IVoluntarioMinisterioRepository voluntarioMinisterioRepository,
            IAgendamentoAtividadeRepository agendamentoAtividadeRepository,
            ISituacaoAgendamentoRepository situacaoAgendamentoRepository,
            IGrupoVoluntarioRepository grupoVoluntarioRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IRegistroLoginRepository registroLoginRepository,
            IRegistroCriacaoRepository registroCriacaoRepository,
            IRegistroAlteracaoRepository registroAlteracaoRepository)
        {
            _context = context;
            Voluntarios = voluntarioRepository;
            Grupos = grupoRepository;
            Usuarios = usuarioRepository;
            UsuarioMinisterios = usuarioMinisterioRepository;
            Agendamentos = agendamentoRepository;
            Ministerios = ministerioRepository;
            Agendas = agendaRepository;
            Atividades = atividadeRepository;
            DataIndisponiveis = dataIndisponivelRepository;
            Escalas = escalaRepository;
            EscalaItens = escalaItemRepository;
            VoluntarioMinisterios = voluntarioMinisterioRepository;
            AgendamentoAtividades = agendamentoAtividadeRepository;
            SituacaoAgendamentos = situacaoAgendamentoRepository;
            GrupoVoluntarios = grupoVoluntarioRepository;
            RefreshTokens = refreshTokenRepository;
            RegistroLogins = registroLoginRepository;
            RegistroCriacoes = registroCriacaoRepository;
            RegistroAlteracoes = registroAlteracaoRepository;
        }

        public async Task IniciarTransacaoAsync()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Já existe uma transação aberta.");
            }

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransacaoAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Nenhuma transação foi iniciada para commit.");
            }

            try
            {
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransacaoAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Nenhuma transação foi iniciada para rollback.");
            }

            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void RollBack()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _transaction?.Dispose();
        }

        public IVoluntarioRepository Voluntarios { get; }
        public IGrupoRepository Grupos { get; }
        public IUsuarioRepository Usuarios { get; }
        public IUsuarioMinisterioRepository UsuarioMinisterios { get; }
        public IAgendamentoRepository Agendamentos { get; }
        public IMinisterioRepository Ministerios { get; }
        public IAgendaRepository Agendas { get; }
        public IAtividadeRepository Atividades { get; }
        public IDataIndisponivelRepository DataIndisponiveis { get; }
        public IEscalaRepository Escalas { get; }
        public IEscalaItemRepository EscalaItens { get; }
        public IVoluntarioMinisterioRepository VoluntarioMinisterios { get; }
        public IAgendamentoAtividadeRepository AgendamentoAtividades { get; }
        public ISituacaoAgendamentoRepository SituacaoAgendamentos { get; }
        public IGrupoVoluntarioRepository GrupoVoluntarios { get; set; }
        public IRefreshTokenRepository RefreshTokens { get; }
        public IRegistroLoginRepository RegistroLogins { get; }
        public IRegistroCriacaoRepository RegistroCriacoes { get; }
        public IRegistroAlteracaoRepository RegistroAlteracoes { get; }
    }
}
