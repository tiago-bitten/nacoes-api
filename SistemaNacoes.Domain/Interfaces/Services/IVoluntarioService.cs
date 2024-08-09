using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IVoluntarioService : IServiceBase<Voluntario>
{
    Task<Voluntario> GetByChaveAcessoAsync(Guid chaveAcesso);
}