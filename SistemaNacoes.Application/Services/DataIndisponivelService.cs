using Microsoft.EntityFrameworkCore.Diagnostics;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Entidades.Infra;
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
    public bool ExisteDataDisponivel(DateTime dataInicial, DateTime dataFinal, List<DataIndisponivel> datasIndisponiveis)
    {
        if (!datasIndisponiveis.Any())
            return true;
        
        foreach (var dataIndisponivel in datasIndisponiveis)
        {
            if (dataInicial >= dataIndisponivel.DataInicio && dataInicial <= dataIndisponivel.DataFinal && !dataIndisponivel.Suspenso)
                return false;
            
            if (dataFinal >= dataIndisponivel.DataInicio && dataFinal <= dataIndisponivel.DataFinal && !dataIndisponivel.Suspenso)
                return false;
        }
        
        return true;
    }
    #endregion

    #region GaranteExisteDataDisponivelAsync
    public void GaranteExisteDataDisponivel(DateTime dataInicial, DateTime dataFinal, List<DataIndisponivel> datasIndisponiveis)
    {
        var existe = ExisteDataDisponivel(dataInicial, dataFinal, datasIndisponiveis);

        if (!existe)
            throw new NacoesAppException(MensagemErroConstant.DataIndisponivel);
    }
    #endregion

    #region Suspender
    public void Suspender(DataIndisponivel dataIndisponivel)
    {
        dataIndisponivel.Suspender();
        Repository.Atualizar(dataIndisponivel);
    }
    #endregion
    
    #region RecuperarPorVoluntarioAsync
    public Task<List<DataIndisponivel>> RecuperarPorVoluntarioAsync(int voluntarioId)
    {
        return Repository.RecuperarPorVoluntarioAsync(voluntarioId);
    }
    #endregion
}