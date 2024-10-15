using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

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