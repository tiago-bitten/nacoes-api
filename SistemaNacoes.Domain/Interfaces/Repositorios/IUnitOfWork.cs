namespace SistemaNacoes.Domain.Interfaces.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        void RollBack();
        Task IniciarTransacaoAsync();
        Task CommitTransacaoAsync();
        Task RollbackTransacaoAsync();
        
        IVoluntarioRepository Voluntarios { get; }
        IGrupoRepository Grupos { get; }
        IUsuarioRepository Usuarios { get; }
        IUsuarioMinisterioRepository UsuarioMinisterios { get; }
        IAgendamentoRepository Agendamentos { get; }
        IMinisterioRepository Ministerios { get; }
        IAgendaRepository Agendas { get; }
        IAtividadeRepository Atividades { get; }
        IDataIndisponivelRepository DataIndisponiveis { get; }
        IEscalaRepository Escalas { get; }
        IEscalaItemRepository EscalaItens { get; }
        IVoluntarioMinisterioRepository VoluntarioMinisterios { get; }
        IAgendamentoAtividadeRepository AgendamentoAtividades { get; }
        ISituacaoAgendamentoRepository SituacaoAgendamentos { get; }
        IGrupoVoluntarioRepository GrupoVoluntarios { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        IRegistroLoginRepository RegistroLogins { get; }
        IRegistroCriacaoRepository RegistroCriacoes { get; }
        IRegistroAlteracaoRepository RegistroAlteracoes { get; }
    }
}