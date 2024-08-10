using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class CreateAgendamento
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IVoluntarioMinisterioService _voluntarioMinisterioService;
    private readonly IServiceBase<Atividade> _atividadeService;
    private readonly IServiceBase<Agenda> _agendaService;

    public CreateAgendamento(IUnitOfWork uow, IMapper mapper, IServiceBase<Atividade> atividadeService, IServiceBase<Agenda> agendaService, IVoluntarioMinisterioService voluntarioMinisterioService)
    {
        _uow = uow;
        _mapper = mapper;
        _atividadeService = atividadeService;
        _agendaService = agendaService;
        _voluntarioMinisterioService = voluntarioMinisterioService;
    }
    
    public async Task<RespostaBase<GetAgendamentoDto>> ExecuteAsync(CreateAgendamentoDto dto)
    {
        var voluntarioMinisterio =
            await _voluntarioMinisterioService.GetAndEnsureExistsAsync(dto.VoluntarioId, dto.MinisterioId);
        var agenda = await _agendaService.GetAndValidateEntityAsync(dto.AgendaId);

        var exitsAgendamento = agenda.Agendamentos.Any(x => x.VoluntarioId == voluntarioMinisterio.VoluntarioId && !x.Removido);
        if (exitsAgendamento)
            throw new Exception(MensagemErrosConstant.AgendamentoJaExiste);
        
        var agendamento = _mapper.Map<Agendamento>(dto);
        await _uow.Agendamentos.AddAsync(agendamento);
        
        foreach (var atividadeId in dto.AtividadeIds)
        {
            var atividade = await _atividadeService.GetAndValidateEntityAsync(atividadeId);
            var existsAtividade = voluntarioMinisterio.Ministerio.Atividades.Any(a => a.Id == atividade.Id);

            if (!existsAtividade)
            {
                _uow.RollBack();
                throw new Exception(MensagemErrosConstant.AtividadeNaoPertenceAoMinisterio);
            }
            var agendamentoAtividade = new AgendamentoAtividade(agendamento, atividade);
            await _uow.AgendamentoAtividades.AddAsync(agendamentoAtividade);
        }
        
        await _uow.CommitAsync();
        
        var agendamentoDto = _mapper.Map<GetAgendamentoDto>(agendamento);

        return new RespostaBase<GetAgendamentoDto>(MensagemRepostasConstant.CreateAgendamento);
    }
}