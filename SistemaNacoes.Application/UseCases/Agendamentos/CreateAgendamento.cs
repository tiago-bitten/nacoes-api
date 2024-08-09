using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class CreateAgendamento
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateAgendamento(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<GetAgendamentoDto>> ExecuteAsync(CreateAgendamentoDto dto)
    {
        var agendamento = _mapper.Map<Agendamento>(dto);

        await _uow.Agendamentos.AddAsync(agendamento);
        await _uow.CommitAsync();

        return new RespostaBase<GetAgendamentoDto>(MensagemRepostasConstant.CreateAgendamento);
    }
}