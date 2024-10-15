using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class MinisterioService : ServiceBase<Ministerio, IMinisterioRepository>, IMinisterioService
{
    public MinisterioService(IMinisterioRepository repository)
        : base(repository)
    {
    }
}