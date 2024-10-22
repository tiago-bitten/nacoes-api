using SistemaNacoes.Application.UseCases.Permissoes.ListarPermissoes.Dtos;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Paginacao;

namespace SistemaNacoes.Application.UseCases.Permissoes.ListarPermissoes;

public class ListarPermissoes : IListarPermissoesUseCase
{
    #region Ctor
    private readonly IPermissoesService _service;

    public ListarPermissoes(IPermissoesService service)
    {
        _service = service;
    }

    #endregion
    
    public async Task<PaginadoResult<ListarPermissoesResult>> ExecutarAsync(ListarPermissoesParam param)
    {
        await _service.VerificaGarantePermissaoAsync(EPermissoes.VisualizarPerfilAcesso,
            "Você não possui permissão para visualizar as permissões.");

        var permissoes = _service.RecuperarTodos();

        var result = new List<ListarPermissoesResult>();

        foreach (var permissao in permissoes)
        {
            result.Add(ListarPermissoesResult.Adicionar(permissao));
        }

        var resultPaginado = result.Paginar(param.Pagina, param.Tamanho);
        
        return resultPaginado;
    }
}