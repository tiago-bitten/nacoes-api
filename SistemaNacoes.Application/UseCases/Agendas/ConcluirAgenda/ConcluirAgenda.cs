﻿using SistemaNacoes.Application.Dtos;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas.ConcluirAgenda;

public class ConcluirAgenda : IConcluirAgendaUseCase
{
    #region Ctor
    private readonly IAgendaService _service;
    private readonly IUnitOfWork _uow;
    private readonly IHistoricoEntidadeService _historicoService;

    public ConcluirAgenda(IAgendaService service, IUnitOfWork uow, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _historicoService = historicoService;
    }
    #endregion

    public async Task ExecutarAsync(int id)
    {
        var agenda = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Concluir(agenda);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("agendas", agenda.Id, "Concluiu agenda.");
        await _uow.CommitTransacaoAsync();
    }
}