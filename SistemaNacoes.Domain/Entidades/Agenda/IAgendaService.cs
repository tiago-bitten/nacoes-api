using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Domain.Entidades.Agenda;

public interface IAgendaService : IServiceBase<Agenda>
{
    void Concluir(Agenda agenda);
}