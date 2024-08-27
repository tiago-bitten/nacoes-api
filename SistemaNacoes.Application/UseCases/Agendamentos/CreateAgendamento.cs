using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        var voluntarioMinisteriosIncludes = GetVoluntarioMinisterioIncludes();
        var agendaIncludes = GetAgendaIncludes();
        
        var voluntarioMinisterio =
            await _voluntarioMinisterioService.GetAndEnsureExistsAsync(dto.VoluntarioId, dto.MinisterioId, voluntarioMinisteriosIncludes);
        
        var agenda = await _agendaService.GetAndEnsureExistsAsync(dto.AgendaId, agendaIncludes);

        if (!agenda.Ativo || agenda.Finalizado)
            throw new Exception(MensagemErroConstant.AgendaNaoDisponivel);
        
        // Em memória
        // var existsAgendamento = agenda.Agendamentos.Exists(x => x.VoluntarioId == voluntarioMinisterio.VoluntarioId && !x.Removido);

        // Em banco
        var existsAgendamento = await _uow.Agendamentos
            .GetAll()
            .AnyAsync(x => x.AgendaId == agenda.Id && x.VoluntarioId == voluntarioMinisterio.VoluntarioId && !x.Removido);
        
        if (existsAgendamento)
            throw new Exception(MensagemErroConstant.AgendamentoJaExiste);

        var agendamentoValidado = await _dataIndisponivelService.EnsureDateIsAvailable(agenda.Id, voluntarioMinisterio.Voluntario.Id);
        
        if (!agendamentoValidado)
            throw new Exception(MensagemErroConstant.DataIndisponivel);
        
        var agendamento = _mapper.Map<Agendamento>(dto);
        await _uow.Agendamentos.AddAsync(agendamento);
        
        var situacaoAgendamento = new SituacaoAgendamento(agendamento);
        await _uow.SituacaoAgendamentos.AddAsync(situacaoAgendamento);

        if (dto.AtividadeIds != null && dto.AtividadeIds.Any())
            foreach (var atividadeId in dto.AtividadeIds)
            {
                var atividade = await _atividadeService.GetAndEnsureExistsAsync(atividadeId);
                
                // Em memória
                // var existsAtividade = voluntarioMinisterio.Ministerio.Atividades.Any(a => a.Id == atividade.Id);

                // Em banco
                var existsAtividade = await _uow.Atividades
                    .GetAll()
                    .AnyAsync(x => x.Id == atividade.Id 
                                   && x.MinisterioId == voluntarioMinisterio.MinisterioId 
                                   && !x.Removido);
                
                if (!existsAtividade)
                {
                    _uow.RollBack();
                    throw new Exception(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
                }

                var agendamentoAtividade = new AgendamentoAtividade(agendamento, atividade);
                await _uow.AgendamentoAtividades.AddAsync(agendamentoAtividade);
            }

        await _uow.CommitAsync();
        
        var agendamentoDto = _mapper.Map<GetAgendamentoDto>(agendamento);

        return new RespostaBase<GetAgendamentoDto>(MensagemRepostaConstant.CreateAgendamento, agendamentoDto);
    }

    private static string[] GetVoluntarioMinisterioIncludes()
    {
        return new[]
        {
            nameof(VoluntarioMinisterio.Voluntario),
            nameof(VoluntarioMinisterio.Ministerio)
        };
    }
    
    private static string[] GetAgendaIncludes()
    {
        return new[]
        {
            nameof(Agenda.Agendamentos)
        };
    }
}