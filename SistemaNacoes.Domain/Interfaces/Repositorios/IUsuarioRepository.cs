using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<bool> ExisteUsuarioCriadoAsync(string email, string? cpf);
    }
}
