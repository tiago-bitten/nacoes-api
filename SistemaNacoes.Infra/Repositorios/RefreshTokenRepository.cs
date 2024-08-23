using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly NacoesDbContext _context;
    private readonly DbSet<RefreshToken> _dbSet;
    
    public RefreshTokenRepository(NacoesDbContext context)
    {
        _context = context;
        _dbSet = context.Set<RefreshToken>();
    }
    
    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _dbSet.AddAsync(refreshToken);
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _dbSet.FirstOrDefaultAsync(rt => rt.Token == token);
    }
    
    public async Task<List<RefreshToken>> FindAsync(Expression<Func<RefreshToken, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public void Revogar(RefreshToken refreshToken)
    {
        refreshToken.Revogado = true;
        _dbSet.Update(refreshToken);
    }
}
