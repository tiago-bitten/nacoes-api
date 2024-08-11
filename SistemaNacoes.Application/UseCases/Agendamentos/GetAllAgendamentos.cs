using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class GetAllAgendamentos
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllAgendamentos(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetAgendamentoDto>>> ExecuteAsync(QueryParametro query)
    {
        var totalAgendamentos = _uow.Agendamentos.GetAll()
            .Where(x => !x.Removido)
            .Count();
        
        var agendamentos = _uow.Agendamentos.GetAll()
            .Skip(query.Skip)
            .Take(query.Take)
            .Where(x => !x.Removido)
            .ToList();
        
        var agendamentosDto = _mapper.Map<List<GetAgendamentoDto>>(agendamentos);
        
        var respostaBase = new RespostaBase<List<GetAgendamentoDto>>(
            MensagemRepostasConstant.GetAgendamentos, agendamentosDto, totalAgendamentos);
        
        return respostaBase;
    }
}