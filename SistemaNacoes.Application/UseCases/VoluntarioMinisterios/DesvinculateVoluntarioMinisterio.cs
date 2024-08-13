﻿using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios;

public class DesvinculateVoluntarioMinisterio
{
    private readonly IUnitOfWork _uow;
    private readonly IVoluntarioMinisterioService _voluntarioMinisterioService;
    
    public DesvinculateVoluntarioMinisterio(IUnitOfWork uow, IVoluntarioMinisterioService voluntarioMinisterioService)
    {
        _uow = uow;
        _voluntarioMinisterioService = voluntarioMinisterioService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int voluntarioId, int ministerioId)
    {
        var voluntarioMinisterio = await _voluntarioMinisterioService.GetAndEnsureExistsAsync(voluntarioId, ministerioId);
        
        voluntarioMinisterio.Ativo = false;
        _uow.VoluntarioMinisterios.Update(voluntarioMinisterio);

        var situacoesAgendamentos = voluntarioMinisterio.Voluntario.Agendamentos
            .Where(x => x.MinisterioId == ministerioId && !x.Agenda.Finalizado && x.Agenda.Ativo)
            .Select(x => x.SituacaoAgendamento);

        foreach (var situacaoAgendamento in situacoesAgendamentos)
        {
            situacaoAgendamento.Ativo = false;
            situacaoAgendamento.Descricao =
                $"{voluntarioMinisterio.Voluntario.Nome} não pertence mais ao ministério {voluntarioMinisterio.Ministerio.Nome}";
            
            _uow.SituacaoAgendamentos.Update(situacaoAgendamento);
        }
        
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(MensagemRepostasConstant.DesvinculateVoluntarioMinisterio);
        
        return respostaBase;
    }
}