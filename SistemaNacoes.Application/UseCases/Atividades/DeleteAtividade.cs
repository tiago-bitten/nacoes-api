using SistemaNacoes.Application.Extensions;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Atividades;

public class DeleteAtividade
{
    private readonly IUnitOfWork _uow;
    private readonly IServiceBase<Atividade> _atividadeService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;

    public DeleteAtividade(IUnitOfWork uow, IServiceBase<Atividade> atividadeService, IAmbienteUsuarioService ambienteUsuarioService)
    {
        _uow = uow;
        _atividadeService = atividadeService;
        _ambienteUsuarioService = ambienteUsuarioService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var usuario = await _ambienteUsuarioService.GetUsuarioAsync();

        if (!usuario.HasPermission(EPermissoes.DELETE_ATIVIDADE))
            throw new Exception(MensagemErrosConstant.SemPermissaoRemoverAtividade);
        
        var atividade = await _atividadeService.GetAndEnsureExistsAsync(id);
        
        if (atividade.Removido)
            throw new Exception(MensagemErrosConstant.AtividadeJaRemovida);
        
        _uow.Atividades.SoftDelete(atividade);
        await _uow.CommitAsync();

        var respostaBase = new RespostaBase<dynamic>(
            MensagemRepostasConstant.DeleteAtividade);
        
        return respostaBase;
    }
}