using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class VoluntarioMinisterioService : IVoluntarioMinisterioService
{
    private readonly IUnitOfWork _uow;

    public VoluntarioMinisterioService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<VoluntarioMinisterio> GetAndEnsureExistsAsync(int voluntarioId, int ministerioId)
    {
        var exists = await _uow.VoluntarioMinisterios.FindAsync(x => x.VoluntarioId == voluntarioId && x.MinisterioId == ministerioId && x.Ativo);
        
        if (exists == null)
            throw new Exception(MensagemErrosConstant.VoluntarioMinisterioNaoEncontrado);
        
        if (exists.Voluntario.Removido || exists.Ministerio.Removido)
            throw new Exception(MensagemErrosConstant.VoluntarioMinisterioNaoEncontrado);
        
        return exists;
    }
}