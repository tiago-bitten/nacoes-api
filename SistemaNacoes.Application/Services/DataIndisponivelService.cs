using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class DataIndisponivelService : ServiceBase<DataIndisponivel, IDataIndisponivelRepository>, IDataIndisponivelService
{
    #region Ctor
    private readonly IAgendaService _agendaService;
    private readonly IVoluntarioService _voluntarioService;
    
    public DataIndisponivelService(IDataIndisponivelRepository repository, IVoluntarioService voluntarioService, IAgendaService agendaService)
        : base(repository)
    {
        _voluntarioService = voluntarioService;
        _agendaService = agendaService;
    }
    #endregion

    #region ExisteDataDisponivelAsync
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
    #endregion

    #region GaranteExisteDataDisponivelAsync
    public async Task GaranteExisteDataDisponivelAsync(int agendaId, int voluntarioId)
    {
        var existe = await ExisteDataDisponivelAsync(agendaId, voluntarioId);

        if (!existe)
            throw new NacoesAppException(MensagemErroConstant.DataIndisponivel);
    }
    #endregion
}