using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class AgendaService : ServiceBase<Agenda>, IAgendaService
{
    public AgendaService(IAgendaRepository repository)
        : base(repository)
    {
    }
}