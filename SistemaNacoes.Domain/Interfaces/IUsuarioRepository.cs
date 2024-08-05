using SistemaNacoes.Domain.Entidades;
namespace SistemaNacoes.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario?> AutenticarAsync(string email, string senha);
        bool VerificarSenha(string senha, string senhaHash);
    }
}
