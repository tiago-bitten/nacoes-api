using SistemaNacoes.Application.UseCases.Voluntarios.ListarVoluntario.Dtos;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Entidades.Voluntario;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Paginacao;

namespace SistemaNacoes.Application.UseCases.Voluntarios.ListarVoluntario;

public class ListarVoluntario : IListarVoluntarioUseCase
{
    #region Ctor

    private readonly IVoluntarioService _service;
    private readonly IPermissoesService _permissoesService;
    
    
    public ListarVoluntario(IVoluntarioService service, IPermissoesService permissoesService)
    {
        _service = service;
        _permissoesService = permissoesService;
    }
    #endregion
    
    public async Task<PaginadoResult<ListarVoluntarioResult>> ExecutarAsync(ListarVoluntarioParam param)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.VisualizarVoluntario, "Você não tem permissão para visualizar voluntários.");

        var voluntariosPaginados = await _service
            .RecuperarTodos()
            .Select(x => new ListarVoluntarioResult
            {
                VoluntarioId = x.Id,
                Nome = x.Nome,
                ChaveAcesso = x.ChaveAcesso
            })
            .PaginarAsync(param.Pagina, param.Tamanho);
        
        return voluntariosPaginados;

    }
}