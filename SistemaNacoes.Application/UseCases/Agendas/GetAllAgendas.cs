using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Agendas;

public class GetAllAgendas
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllAgendas(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetAgendaDto>>> ExecuteAsync(QueryParametro query)
    {
        var totalAgendas = _uow.Agendas.GetAll()
            .Count();
        
        var agendas = _uow.Agendas.GetAll()
            .Skip(query.Skip)
            .Take(query.Take)
            .ToList();
        
        var agendasDto = _mapper.Map<List<GetAgendaDto>>(agendas);
        
        var respostaBase = new RespostaBase<List<GetAgendaDto>>(
            MensagemRepostasConstant.GetAgendas, agendasDto, totalAgendas);
        
        return respostaBase;
    }
}