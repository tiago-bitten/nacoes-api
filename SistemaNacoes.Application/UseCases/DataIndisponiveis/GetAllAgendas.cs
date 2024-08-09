using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.Dtos.DataIndisponiveis;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis;

public class GetAllAgendas
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllAgendas(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetAgendaDto>>> ExecuteAsync()
    {
        var dataIndisponiveis = _uow.DataIndisponiveis.GetAll();
        
        return _mapper.Map<RespostaBase<List<GetAgendaDto>>>(dataIndisponiveis);
    }
}