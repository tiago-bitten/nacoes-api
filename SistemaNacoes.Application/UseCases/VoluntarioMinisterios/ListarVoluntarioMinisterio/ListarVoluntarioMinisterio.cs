using SistemaNacoes.Application.Dtos;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.ListarVoluntarioMinisterio.Dtos;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Paginacao;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios.ListarVoluntarioMinisterio;

public class ListarVoluntarioMinisterio : IListarVoluntarioMinisterioUseCase
{
    #region Ctor
    private readonly IVoluntarioMinisterioService _service;
    private readonly IPermissoesService _permissoesService;
    
    public ListarVoluntarioMinisterio(IVoluntarioMinisterioService service, IPermissoesService permissoesService)
    {
        _service = service;
        _permissoesService = permissoesService;
    }
    #endregion
    
    public async Task<PaginadoResult<ListarVoluntarioMinisterioResult>> ExecutarAsync(ListarVoluntarioMinisterioParam param)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.VisualizarVoluntarioMinisterio,
            "Você não tem permissão para visualizar voluntários.");

        var voluntarioMinisteriosPaginados = await _service
            .RecuperarTodos()
            .Select(x => new ListarVoluntarioMinisterioResult
            {
                VoluntarioMinisterioId = x.Id
            })
            .PaginarAsync(param.Pagina, param.Tamanho);

        return voluntarioMinisteriosPaginados;
    }
}