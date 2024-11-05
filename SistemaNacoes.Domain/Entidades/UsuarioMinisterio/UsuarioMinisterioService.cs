using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Domain.Entidades.UsuarioMinisterio;

public class UsuarioMinisterioService : ServiceBase<UsuarioMinisterio, IUsuarioMinisterioRepository>, IUsuarioMinisterioService
{
    public UsuarioMinisterioService(IUsuarioMinisterioRepository repository) : base(repository)
    {
    }

    public async Task GaranteNaoExisteUsuarioMinisterioAsync(int usuarioId, int ministerioId)
    {
        var existe = await Repository.ExisteUsuarioMinisterioAsync(usuarioId, ministerioId);
        
        if (existe)
            throw new NacoesAppException("Usuário já pertence a este ministério.");
    }
}