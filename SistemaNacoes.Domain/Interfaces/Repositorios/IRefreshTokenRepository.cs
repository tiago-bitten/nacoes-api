using System.Linq.Expressions;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios;

public interface IRefreshTokenRepository
{
    Task AdicionarAsync(RefreshToken refreshToken);
    Task<RefreshToken?> RecuperarPorTokenAsync(string token);
    Task<List<RefreshToken>> BuscarAsync(Expression<Func<RefreshToken, bool>> predicate);
    void Atualizar(RefreshToken refreshToken);
}