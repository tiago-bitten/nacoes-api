using System.Linq.Expressions;

namespace SistemaNacoes.Domain.Entidades.RefreshToken;

public interface IRefreshTokenRepository
{
    Task AdicionarAsync(RefreshToken refreshToken);
    Task<RefreshToken?> RecuperarPorTokenAsync(string token);
    Task<List<RefreshToken>> BuscarAsync(Expression<Func<RefreshToken, bool>> predicate);
    void Atualizar(RefreshToken refreshToken);
}