using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Atividades;

public class DeleteAtividade
{
    private readonly IUnitOfWork _uow;
    private readonly IServiceBase<Atividade> _atividadeService;

    public DeleteAtividade(IUnitOfWork uow, IServiceBase<Atividade> atividadeService)
    {
        _uow = uow;
        _atividadeService = atividadeService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var atividade = await _atividadeService.GetAndEnsureExistsAsync(id);
        
        if (atividade.Removido)
            throw new Exception(MensagemErrosConstant.AtividadeJaRemovida);
        
        _uow.Atividades.SoftDeleteAsync(atividade);
        await _uow.CommitAsync();

        var respostaBase = new RespostaBase<dynamic>(MensagemRepostasConstant.DeleteAtividade);
        
        return respostaBase;
    }
}