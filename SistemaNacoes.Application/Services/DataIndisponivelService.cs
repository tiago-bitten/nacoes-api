﻿using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class DataIndisponivelService : ServiceBase<DataIndisponivel>, IDataIndisponivelService
{
    #region ctor
    private readonly IAgendaService _agendaService;
    private readonly IVoluntarioService _voluntarioService;
    
    public DataIndisponivelService(IDataIndisponivelRepository repository, IVoluntarioService voluntarioService, IAgendaService agendaService)
        : base(repository)
    {
        _voluntarioService = voluntarioService;
        _agendaService = agendaService;
    }
    #endregion

    public async Task<bool> ExisteDataDisponivelAsync(int agendaId, int voluntarioId)
    {
        var agenda = await _agendaService.RecuperaGaranteExisteAsync(agendaId);
        var voluntario = await _voluntarioService.RecuperaGaranteExisteAsync(voluntarioId, "DataIndisponiveis");
        
        var datasIndisponiveis = voluntario.GetDataIndisponiveis();
        
        if (!datasIndisponiveis.Any())
            return true;
        
        foreach (var dataIndisponivel in datasIndisponiveis)
        {
            if (agenda.DataInicio >= dataIndisponivel.DataInicio && agenda.DataInicio <= dataIndisponivel.DataFinal)
                return false;
            
            if (agenda.DataFinal >= dataIndisponivel.DataInicio && agenda.DataFinal <= dataIndisponivel.DataFinal)
                return false;
        }
        
        return true;
    }

    public async Task GaranteExisteDataDisponivelAsync(int agendaId, int voluntarioId)
    {
        var exists = await ExisteDataDisponivelAsync(agendaId, voluntarioId);

        if (!exists)
            throw new NacoesAppException(MensagemErroConstant.DataIndisponivel);
    }
}