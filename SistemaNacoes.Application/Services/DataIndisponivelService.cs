using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class DataIndisponivelService : ServiceBase<DataIndisponivel>, IDataIndisponivelService
{
    private readonly IAgendaService _agendaService;
    private readonly IVoluntarioService _voluntarioService;
    
    public DataIndisponivelService(IDataIndisponivelRepository repository, IVoluntarioService voluntarioService, IAgendaService agendaService)
        : base(repository)
    {
        _voluntarioService = voluntarioService;
        _agendaService = agendaService;
    }

    public async Task<bool> EnsureDateIsAvailable(int agendaId, int voluntarioId)
    {
        var agenda = await _agendaService.GetAndEnsureExistsAsync(agendaId);
        
        var voluntarioIncludes = new[]
        {
            nameof(Voluntario.DatasIndisponiveis)
        };
        var voluntario = await _voluntarioService.GetAndEnsureExistsAsync(voluntarioId, voluntarioIncludes);
        
        var datasIndisponiveis = voluntario.DatasIndisponiveis
            .FindAll(x => !x.Removido && !x.Suspenso);
        
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
}