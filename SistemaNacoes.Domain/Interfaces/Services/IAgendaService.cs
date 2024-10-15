using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAgendaService : IServiceBase<Agenda>
{
    void Concluir(Agenda agenda);
}