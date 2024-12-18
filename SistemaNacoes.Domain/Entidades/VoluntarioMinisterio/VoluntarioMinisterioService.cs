﻿using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.VoluntarioMinisterio;

public class VoluntarioMinisterioService : ServiceBase<VoluntarioMinisterio, IVoluntarioMinisterioRepository>, IVoluntarioMinisterioService
{
    public VoluntarioMinisterioService(IVoluntarioMinisterioRepository repository) : base(repository)
    {
    }

    public Task<bool> ExisteVoluntarioNoMinisterio(int voluntarioId, int ministerioId)
    {
        return Repository.AlgumAsync(x => x.VoluntarioId == voluntarioId 
                                          && x.MinisterioId == ministerioId);
    }

    public async Task GaranteNaoExisteVoluntarioNoMinisterio(int voluntarioId, int ministerioId)
    {
        var existe = await ExisteVoluntarioNoMinisterio(voluntarioId, ministerioId);
        
        if (existe)
            throw new NacoesAppException($"Voluntário já cadastrado no ministério {voluntarioId}.");
    }
}