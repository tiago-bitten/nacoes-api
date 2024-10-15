using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Domain.Interfaces
{
    public interface IVoluntarioRepository : IRepositoryBase<Voluntario>
    {
        Task<Voluntario?> RecuperarPorChaveAcessoAsync(Guid chaveAcesso, params string[]? includes);
    }
}
