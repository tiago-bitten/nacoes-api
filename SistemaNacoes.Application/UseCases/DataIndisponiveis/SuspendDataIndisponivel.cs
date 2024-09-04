using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis;

public class SuspendDataIndisponivel
{
    private readonly IUnitOfWork _uow;
    private readonly IDataIndisponivelService _dataIndisponivelService;

    public SuspendDataIndisponivel(IUnitOfWork uow, IDataIndisponivelService dataIndisponivelService)
    {
        _uow = uow;
        _dataIndisponivelService = dataIndisponivelService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var dataIndisponivel = await _dataIndisponivelService.GetAndEnsureExistsAsync(id);
        dataIndisponivel.Suspenso = true;
        
        _uow.DataIndisponiveis.Update(dataIndisponivel);
        await _uow.CommitAsync();
        
        return new RespostaBase<dynamic>(RespostaBaseMensagem.SuspendDataIndisponivel);
    }
}