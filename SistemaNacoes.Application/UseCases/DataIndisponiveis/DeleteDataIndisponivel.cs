using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis;

public class DeleteDataIndisponivel
{
    private readonly IUnitOfWork _uow;
    private readonly IDataIndisponivelService _dataIndisponivelService;

    public DeleteDataIndisponivel(IUnitOfWork uow, IDataIndisponivelService dataIndisponivelService)
    {
        _uow = uow;
        _dataIndisponivelService = dataIndisponivelService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var dataIndisponivel = await _dataIndisponivelService.GetAndEnsureExistsAsync(id);
        
        if (dataIndisponivel.Removido)
            throw new Exception(MensagemErrosConstant.DataIndisponivelJaRemovido);
            
        _uow.DataIndisponiveis.SoftDelete(dataIndisponivel);
        await _uow.CommitAsync();
        
        return new RespostaBase<dynamic>(MensagemRepostasConstant.DeleteDataIndisponivel);
    }
}