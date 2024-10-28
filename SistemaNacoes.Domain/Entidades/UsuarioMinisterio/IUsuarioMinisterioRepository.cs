using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Domain.Entidades.UsuarioMinisterio
{
    public interface IUsuarioMinisterioRepository : IRepositoryBase<UsuarioMinisterio>
    {
        Task<bool> ExisteUsuarioMinisterioAsync(int usuarioId, int ministerioId);
    }
}
