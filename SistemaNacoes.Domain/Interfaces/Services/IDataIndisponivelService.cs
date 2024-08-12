using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IDataIndisponivelService : IServiceBase<DataIndisponivel>
{
    bool EnsureDateIsAvailable(Agenda agenda, Voluntario voluntario);
}