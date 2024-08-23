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
    private readonly IAgendaService _agendaService;
    private readonly IServiceBase<Atividade> _atividadeService;
    private readonly IDataIndisponivelService _dataIndisponivelService;

    public CreateAgendamento(IUnitOfWork uow, IMapper mapper, IServiceBase<Atividade> atividadeService, IAgendaService agendaService, IVoluntarioMinisterioService voluntarioMinisterioService, IDataIndisponivelService dataIndisponivelService)
    {
        _uow = uow;
        _mapper = mapper;
        _atividadeService = atividadeService;
        _agendaService = agendaService;
        _voluntarioMinisterioService = voluntarioMinisterioService;
        _dataIndisponivelService = dataIndisponivelService;
    }
    
    public async Task<RespostaBase<GetAgendamentoDto>> ExecuteAsync(CreateAgendamentoDto dto)
    {
        var voluntarioMinisteriosIncludes = new[] 
            { 
                nameof(VoluntarioMinisterio.Voluntario),
                nameof(VoluntarioMinisterio.Ministerio) 
            };
        
        var agendaIncludes = new[]
        {
            nameof(Agenda.Agendamentos)
        };
        
        var voluntarioMinisterio =
            await _voluntarioMinisterioService.GetAndEnsureExistsAsync(dto.VoluntarioId, dto.MinisterioId, voluntarioMinisteriosIncludes);
        
        var agenda = await _agendaService.GetAndEnsureExistsAsync(dto.AgendaId, agendaIncludes);

        if (!agenda.Ativo || agenda.Finalizado)
            throw new Exception(MensagemErrosConstant.AgendaNaoDisponivel);
        
        var exitsAgendamento = agenda.Agendamentos.Exists(x => x.VoluntarioId == voluntarioMinisterio.VoluntarioId && !x.Removido);
        if (exitsAgendamento)
            throw new Exception(MensagemErrosConstant.AgendamentoJaExiste);

        var agendamentoValidado = await _dataIndisponivelService.EnsureDateIsAvailable(agenda.Id, voluntarioMinisterio.Voluntario.Id);
        
        if (!agendamentoValidado)
            throw new Exception(MensagemErrosConstant.DataIndisponivel);
        
        var agendamento = _mapper.Map<Agendamento>(dto);
        await _uow.Agendamentos.AddAsync(agendamento);
        
        var situacaoAgendamento = new SituacaoAgendamento(agendamento);
        await _uow.SituacaoAgendamentos.AddAsync(situacaoAgendamento);

        if (dto.AtividadeIds != null && dto.AtividadeIds.Any())
            foreach (var atividadeId in dto.AtividadeIds)
            {
                var atividade = await _atividadeService.GetAndEnsureExistsAsync(atividadeId);
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

        return new RespostaBase<GetAgendamentoDto>(MensagemRepostasConstant.CreateAgendamento, agendamentoDto);
    }
}