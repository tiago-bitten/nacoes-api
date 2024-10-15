using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class VoluntarioMinisterioService : ServiceBase<VoluntarioMinisterio, IVoluntarioMinisterioRepository>, IVoluntarioMinisterioService
{
    public VoluntarioMinisterioService(IVoluntarioMinisterioRepository repository) : base(repository)
    {
    }
}