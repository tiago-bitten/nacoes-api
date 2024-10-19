using AutoMapper;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;

public class CriarAgendamento : ICriarAgendamentoUseCase
{
    #region ctor
    private readonly IAgendamentoService _service;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;
    private readonly IVoluntarioMinisterioService _voluntarioMinisterioService;
    private readonly IAgendaService _agendaService;
    private readonly IAtividadeService _atividadeService;
    private readonly IDataIndisponivelService _dataIndisponivelService;
    private readonly IHistoricoEntidadeService _registroCriacaoService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IAgendamentoAtividadeService _agendamentoAtividadeService;
    private readonly IPermissoesService _permissoesService;
    
    public CriarAgendamento(IUnitOfWork uow,
        IMapper mapper,
        IAtividadeService atividadeService,
        IAgendaService agendaService,
        IVoluntarioMinisterioService voluntarioMinisterioService,
        IDataIndisponivelService dataIndisponivelService,
        IHistoricoEntidadeService registroCriacaoService,
        IAmbienteUsuarioService ambienteUsuarioService,
        IAgendamentoService agendamentoService,
        IAgendamentoAtividadeService agendamentoAtividadeService,
        IPermissoesService permissoesService)
    {
        _uow = uow;
        _mapper = mapper;
        _atividadeService = atividadeService;
        _agendaService = agendaService;
        _voluntarioMinisterioService = voluntarioMinisterioService;
        _dataIndisponivelService = dataIndisponivelService;
        _registroCriacaoService = registroCriacaoService;
        _ambienteUsuarioService = ambienteUsuarioService;
        _service = agendamentoService;
        _agendamentoAtividadeService = agendamentoAtividadeService;
        _permissoesService = permissoesService;
    }
    #endregion
    
    public async Task<CriarAgendamentoResult> ExecutarAsync(CriarAgendamentoRequest dto)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CREATE_AGENDAMENTO, "Você não possui permissão para criar agendamentos");
        
        var voluntarioMinisterio =
            await _voluntarioMinisterioService.RecuperaGaranteExisteAsync(dto.VoluntarioMinisterioId, "Voluntario", "Ministerio");

        var agenda = await _agendaService.RecuperaGaranteExisteAsync(dto.AgendaId);

        agenda.ValidarStatus();
        
        await _service.GaranteNaoExisteVoluntarioAgendadoAsync(agenda.Id, voluntarioMinisterio.VoluntarioId);
        await _dataIndisponivelService.GaranteExisteDataDisponivelAsync(agenda.Id, voluntarioMinisterio.VoluntarioId);

        var agendamento = new Agendamento(voluntarioMinisterio.Voluntario, voluntarioMinisterio.Ministerio, agenda);
        
        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(agendamento);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _registroCriacaoService.RegistrarAsync("agendamentos", agendamento.Id, "Agendamento criado");
        await _uow.CommitTransacaoAsync();
        
        var agendamentoResponse = _mapper.Map<CriarAgendamentoResult>(agendamento);

        return agendamentoResponse;
    }
}