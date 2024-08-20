﻿using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class AgendamentoAtividadeService : IAgendamentoAtividadeService
{
    private readonly IUnitOfWork _uow;
    private readonly IServiceBase<Agendamento> _agendamentoService;
    private readonly IServiceBase<Atividade> _atividadeService;

    public AgendamentoAtividadeService(IUnitOfWork uow, IServiceBase<Agendamento> agendamentoService, IServiceBase<Atividade> atividadeService)
    {
        _uow = uow;
        _agendamentoService = agendamentoService;
        _atividadeService = atividadeService;
    }

    public async Task<AgendamentoAtividade> GetAndEnsureExistsAsync(int agendamentoId, int atividadeId)
    {
        await _agendamentoService.GetAndEnsureExistsAsync(agendamentoId);
        await _atividadeService.GetAndEnsureExistsAsync(atividadeId);
        
        var agendamentoAtividade = await _uow.AgendamentoAtividades
            .FindAsync(x => x.AgendamentoId == agendamentoId && x.AtividadeId == atividadeId && !x.Removido);
        
        if (agendamentoAtividade is null)
            throw new Exception(MensagemErrosConstant.AgendamentoAtividadeNaoEncontrado);
        
        return agendamentoAtividade;
    }
}