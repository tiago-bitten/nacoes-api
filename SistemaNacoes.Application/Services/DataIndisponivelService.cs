using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class DataIndisponivelService : ServiceBase<DataIndisponivel>, IDataIndisponivelService
{
    public DataIndisponivelService(IDataIndisponivelRepository repository)
        : base(repository)
    {
    }

    public bool EnsureDateIsAvailable(Agenda agenda, Voluntario voluntario)
    {
        var datasIndisponiveis = voluntario.DatasIndisponiveis
            .FindAll(x => x is { Suspenso: false, Removido: false });
        
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