﻿using SistemaNacoes.Application.Responses;
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

    // TODO URGENTE: Refatorar esse service, voluntariominsiterio agora tem identificador unico
    public async Task<VoluntarioMinisterio> GetAndEnsureExistsAsync(int voluntarioId, int ministerioId, params string[]? includes)
    {
        var exists = await _uow.VoluntarioMinisterios
            .FindAsync(x => x.VoluntarioId == voluntarioId 
                            && x.MinisterioId == ministerioId 
                            && !x.Removido, includes);
        
        if (exists == null)
            throw new Exception(MensagemErroConstant.VoluntarioMinisterioNaoEncontrado);
        
        if (exists.Voluntario.Removido || exists.Ministerio.Removido)
            throw new Exception(MensagemErroConstant.VoluntarioMinisterioNaoEncontrado);
        
        return exists;
    }
}