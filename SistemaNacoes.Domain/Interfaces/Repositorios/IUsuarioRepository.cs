using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario?> RecuperarPorEmail(string email);
        Task<Usuario?> RecuperarPorCpf(string cpf);
    }
}
