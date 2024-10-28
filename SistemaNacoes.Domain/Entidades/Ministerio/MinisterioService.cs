using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces;

namespace SistemaNacoes.Domain.Entidades.Ministerio;

public class MinisterioService : ServiceBase<Ministerio, IMinisterioRepository>, IMinisterioService
{
    public MinisterioService(IMinisterioRepository repository)
        : base(repository)
    {
    }
}