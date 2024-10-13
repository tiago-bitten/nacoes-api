using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;

public class CriarAgendamento : ICriarAgendamentoUseCase
{
    #region ctor
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IVoluntarioMinisterioService _voluntarioMinisterioService;
    private readonly IAgendaService _agendaService;
    private readonly IAtividadeService _atividadeService;
    private readonly IDataIndisponivelService _dataIndisponivelService;
    private readonly IRegistroCriacaoService _registroCriacaoService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IAgendamentoService _agendamentoService;
    private readonly IAgendamentoAtividadeService _agendamentoAtividadeService;
    private readonly IPermissoesService _permissoesService;
    
    public CriarAgendamento(IUnitOfWork uow, IMapper mapper, IAtividadeService atividadeService, IAgendaService agendaService, IVoluntarioMinisterioService voluntarioMinisterioService, IDataIndisponivelService dataIndisponivelService, IRegistroCriacaoService registroCriacaoService, IAmbienteUsuarioService ambienteUsuarioService, IAgendamentoService agendamentoService, IAgendamentoAtividadeService agendamentoAtividadeService, IPermissoesService permissoesService)
    {
        _uow = uow;
        _mapper = mapper;
        _atividadeService = atividadeService;
        _agendaService = agendaService;
        _voluntarioMinisterioService = voluntarioMinisterioService;
        _dataIndisponivelService = dataIndisponivelService;
        _registroCriacaoService = registroCriacaoService;
        _ambienteUsuarioService = ambienteUsuarioService;
        _agendamentoService = agendamentoService;
        _agendamentoAtividadeService = agendamentoAtividadeService;
        _permissoesService = permissoesService;
    }
    #endregion
    
    public async Task<CriarAgendamentoResponse> ExecutarAsync(CriarAgendamentoRequest dto)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CREATE_AGENDAMENTO, "Você não possui permissão para criar agendamentos");
        
        var voluntarioMinisterio =
            await _voluntarioMinisterioService.RecuperaGaranteExisteAsync(dto.VoluntarioMinisterioId);
        
        var agenda = await _agendaService.RecuperaGaranteExisteAsync(dto.AgendaId);

        agenda.VerificaGaranteDisponibilidade();
        
        await _agendamentoService.GaranteNaoExisteVoluntarioAgendadoAsync(agenda.Id, voluntarioMinisterio.VoluntarioId);
        await _dataIndisponivelService.GaranteExisteDataDisponivelAsync(agenda.Id, voluntarioMinisterio.VoluntarioId);
        
        var agendamento = _mapper.Map<Agendamento>(dto);
        await _uow.Agendamentos.AdicionarAsync(agendamento);
        
        // TODO: passar para AgendamentoAtividadeService
        #region adicionando atividades no agendamento
        if (dto.AtividadeIds != null && dto.AtividadeIds.Any())
            foreach (var atividadeId in dto.AtividadeIds)
            {
                var atividade = await _atividadeService.RecuperaGaranteExisteAsync(atividadeId);

                await _atividadeService.EnsureExistsAtividadeNoMinisterioAsync(atividade.Id, voluntarioMinisterio.MinisterioId);
                
                var agendamentoAtividade = new AgendamentoAtividade(agendamento, atividade);
                await _uow.AgendamentoAtividades.AdicionarAsync(agendamentoAtividade);
            }
        #endregion

        await _uow.CommitAsync();
        
        await _registroCriacaoService.LogAsync("agendamentos", agendamento.Id);
        await _registroCriacaoService.LogRangeAsync("agendamentos_atividades", agendamento.AgendamentoAtividades.Select(x => x.Id));
        
        var agendamentoResponse = _mapper.Map<CriarAgendamentoResponse>(agendamento);

        return agendamentoResponse;
    }
}