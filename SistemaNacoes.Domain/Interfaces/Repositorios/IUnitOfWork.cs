namespace SistemaNacoes.Domain.Interfaces.Repositorios;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
    void RollBack();
    
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
}