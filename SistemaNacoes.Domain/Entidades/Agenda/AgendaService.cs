using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Agenda;

public class AgendaService : ServiceBase<Agenda, IAgendaRepository>, IAgendaService
{
    public AgendaService(IAgendaRepository repository)
        : base(repository)
    {
    }

    public void Concluir(Agenda agenda)
    {
        agenda.Concluir();
        Repository.Atualizar(agenda);
    }
}