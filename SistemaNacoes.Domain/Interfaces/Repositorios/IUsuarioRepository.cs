using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario?> RecuperarPorEmailAsync(string email);
        Task<Usuario?> RecuperarPorCpfAsync(string cpf);
    }
}
