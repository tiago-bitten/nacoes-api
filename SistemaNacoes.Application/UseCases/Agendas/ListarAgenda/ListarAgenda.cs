using AutoMapper;
using SistemaNacoes.Application.UseCases.Agendas.ListarAgenda.Dto;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Extensions;
using SistemaNacoes.Shared.Paginacao;

namespace SistemaNacoes.Application.UseCases.Agendas.ListarAgenda;

public class ListarAgenda : IListarAgendaUseCase
{
    #region Ctor
    private readonly IAgendaService _service;
    private readonly IMapper _mapper;

    public ListarAgenda(IAgendaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    #endregion
    
    public async Task<PaginadoResult<ListarAgendaResult>> ExecutarAsync(ListarAgendaParams param)
    {
        var agendasPaginadas = await _service
            .RecuperarTodos("Agendamentos")
            .Where(x => x.DataInicio.Month == param.Mes
                        && x.DataInicio.Year == param.Ano)
            .Select(x => new ListarAgendaResult
            {
                AgendaId = x.Id,
                DataInicio = x.DataInicio,
                DataFinal = x.DataFinal,
                Nome = x.Titulo,
                TotalAgendamentos = x.Agendamentos.Count
            })
            .PaginarAsync(param.Pagina, param.Tamanho);

        return agendasPaginadas;
    }
}