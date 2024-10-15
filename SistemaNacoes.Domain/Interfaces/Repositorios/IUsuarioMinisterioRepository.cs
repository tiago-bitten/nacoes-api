using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios
{
    public interface IUsuarioMinisterioRepository : IRepositoryBase<UsuarioMinisterio>
    {
        Task<bool> ExisteUsuarioMinisterioAsync(int usuarioId, int ministerioId);
    }
}
