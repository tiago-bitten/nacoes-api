using System.Linq.Expressions;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken refreshToken);
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task<List<RefreshToken>> FindAsync(Expression<Func<RefreshToken, bool>> predicate);
    void Revogar(RefreshToken refreshToken);
}