using SistemaNacoes.Application.UseCases.Atividades.ListarAtividade.Dtos;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Paginacao;

namespace SistemaNacoes.Application.UseCases.Atividades.ListarAtividade;

public class ListarAtividade : IListarAtividadeUseCase
{
    #region Ctor

    private readonly IAtividadeService _service;
    private readonly IPermissoesService _permissoesService;

    public ListarAtividade(IAtividadeService service, IPermissoesService permissoesService)
    {
        _service = service;
        _permissoesService = permissoesService;
    }

    #endregion
    
    public async Task<PaginadoResult<ListarAtividadeResult>> ExecutarAsync(ListarAtividadeParams param)
    {
        var atividadesPaginadas = await _service
            .RecuperarTodos("Ministerio")
            .Select(x => new ListarAtividadeResult
            {
                AtividadeId = x.Id,
                Nome = x.Nome,
                MaximoVoluntarios = x.MaximoVoluntarios,
                Ministerio = x.Ministerio.Id
            })
            .PaginarAsync(param.Pagina, param.Tamanho);
        
        return atividadesPaginadas;
    }
}