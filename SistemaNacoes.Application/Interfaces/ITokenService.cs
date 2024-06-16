using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
