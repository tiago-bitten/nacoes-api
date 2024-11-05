using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.UsuarioMinisterio;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class UsuarioMinisterioRepository : RepositoryBase<UsuarioMinisterio>, IUsuarioMinisterioRepository
{
    public UsuarioMinisterioRepository(NacoesDbContext context)
        : base(context)
    {
    }

    public async Task<bool> ExisteUsuarioMinisterioAsync(int usuarioId, int ministerioId)
    {
        return await AlgumAsync(x => x.UsuarioId == usuarioId && x.MinisterioId == ministerioId);
    }
}