﻿using System.Runtime.CompilerServices;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Ministerios;

public class DeleteMinisterio
{
    private readonly IUnitOfWork _uow;
    private readonly IMinisterioService _ministerioService;

    public DeleteMinisterio(IUnitOfWork uow, IMinisterioService ministerioService)
    {
        _uow = uow;
        _ministerioService = ministerioService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var includes = new[] { nameof(Ministerio.VoluntarioMinisterios) };
        
        var ministerio = await _ministerioService.GetAndEnsureExistsAsync(id, includes: includes);
        
        _uow.Ministerios.SoftDelete(ministerio);

        foreach (var voluntarioMinisterio in ministerio.VoluntarioMinisterios)
        {
            _uow.VoluntarioMinisterios.SoftDelete(voluntarioMinisterio);
        }
        
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(
            RespostaBaseMensagem.DeleteMinisterio);
        
        return respostaBase;
    }
}