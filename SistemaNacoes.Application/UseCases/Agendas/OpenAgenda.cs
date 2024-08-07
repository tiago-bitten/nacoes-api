using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Agendas;

public class OpenAgenda
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public OpenAgenda(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<GetAgendaDto>> ExecuteAsync(OpenAgendaDto dto)
    {
        if (dto.DataFinal < dto.DataInicio)
            throw new Exception("Data final não pode ser menor que a data inicial");

        var agenda = _mapper.Map<Agenda>(dto);

        await _uow.Agendas.AddAsync(agenda);
        await _uow.CommitAsync();

        var agendaDto = _mapper.Map<GetAgendaDto>(agenda);

        var responstaBase = new RespostaBase<GetAgendaDto>(MensagemRepostasConstant.OpenAgenda, agendaDto);
        
        return responstaBase;
    }
}