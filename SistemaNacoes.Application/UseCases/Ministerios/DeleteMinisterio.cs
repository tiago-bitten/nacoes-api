﻿using System.Runtime.CompilerServices;
using SistemaNacoes.Application.Responses;
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
        var ministerio = await _ministerioService.GetAndEnsureExistsAsync(id);
        
        if (ministerio.Removido)
            throw new Exception(MensagemErrosConstant.MinisterioJaRemovido);
        
        _uow.Ministerios.SoftDeleteAsync(ministerio);        
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(MensagemRepostasConstant.DeleteMinisterio);
        
        return respostaBase;
    }
}