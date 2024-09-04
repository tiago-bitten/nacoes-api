using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Extensions;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class CreateAgendamento
{
    #region dp
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IVoluntarioMinisterioService _voluntarioMinisterioService;
    private readonly IAgendaService _agendaService;
    private readonly IServiceBase<Atividade> _atividadeService;
    private readonly IDataIndisponivelService _dataIndisponivelService;
    private readonly IRegistroCriacaoService _registroCriacaoService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    #endregion
    
    #region ctor
    public CreateAgendamento(IUnitOfWork uow, IMapper mapper, IServiceBase<Atividade> atividadeService, IAgendaService agendaService, IVoluntarioMinisterioService voluntarioMinisterioService, IDataIndisponivelService dataIndisponivelService, IRegistroCriacaoService registroCriacaoService, IAmbienteUsuarioService ambienteUsuarioService)
    {
        _uow = uow;
        _mapper = mapper;
        _atividadeService = atividadeService;
        _agendaService = agendaService;
        _voluntarioMinisterioService = voluntarioMinisterioService;
        _dataIndisponivelService = dataIndisponivelService;
        _registroCriacaoService = registroCriacaoService;
        _ambienteUsuarioService = ambienteUsuarioService;
    }
    #endregion
    
    public async Task<RespostaBase<GetAgendamentoDto>> ExecuteAsync(CreateAgendamentoDto dto)
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();

        if (!usuarioLogado.HasPermission(EPermissoes.CREATE_AGENDAMENTO))
            throw new Exception(MensagemErroConstant.SemPermissaoParaCriarAgendamento);
        
        var voluntarioMinisteriosIncludes = GetVoluntarioMinisterioIncludes();
        var agendaIncludes = GetAgendaIncludes();
        
        var voluntarioMinisterio =
            await _voluntarioMinisterioService.GetAndEnsureExistsAsync(dto.VoluntarioId, dto.MinisterioId, voluntarioMinisteriosIncludes);
        
        var agenda = await _agendaService.GetAndEnsureExistsAsync(dto.AgendaId, agendaIncludes);

        agenda.CheckStatus();
        
        #region consulta em memoria
        // var existsAgendamento = agenda.Agendamentos.Exists(x => x.VoluntarioId == voluntarioMinisterio.VoluntarioId && !x.Removido);
        #endregion
        
        #region consulta no banco
        var existsAgendamento = await _uow.Agendamentos
            .GetAll()
            .AnyAsync(x => x.AgendaId == agenda.Id && x.VoluntarioId == voluntarioMinisterio.VoluntarioId && !x.Removido);
        #endregion
        
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
                
                #region consulta em memoria
                // var existsAtividade = voluntarioMinisterio.Ministerio.Atividades.Any(a => a.Id == atividade.Id);
                #endregion
                
                #region consulta no banco
                var existsAtividade = await _uow.Atividades
                    .GetAll()
                    .AnyAsync(x => x.Id == atividade.Id 
                                   && x.MinisterioId == voluntarioMinisterio.MinisterioId 
                                   && !x.Removido);
                #endregion
                
                if (!existsAtividade)
                {
                    // TODO: passar o rollback para middleware de exceções
                    _uow.RollBack();
                    throw new Exception(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
                }

                var agendamentoAtividade = new AgendamentoAtividade(agendamento, atividade);
                await _uow.AgendamentoAtividades.AddAsync(agendamentoAtividade);
            }

        await _uow.CommitAsync();
        
        await _registroCriacaoService.LogAsync("agendamentos", agendamento.Id);
        
        var agendamentoDto = _mapper.Map<GetAgendamentoDto>(agendamento);

        var respostaBase = new RespostaBase<GetAgendamentoDto>(
            RespostaBaseMensagem.CreateAgendamento, agendamentoDto);

        return respostaBase;
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