using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;

public class CriarAgendamento : UseCaseBase<Agendamento, IAgendamentoService>, ICriarAgendamentoUseCase
{
    #region ctor
    private readonly IVoluntarioMinisterioService _voluntarioMinisterioService;
    private readonly IAgendaService _agendaService;
    private readonly IAtividadeService _atividadeService;
    private readonly IDataIndisponivelService _dataIndisponivelService;
    private readonly IRegistroCriacaoService _registroCriacaoService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IAgendamentoService _agendamentoService;
    private readonly IAgendamentoAtividadeService _agendamentoAtividadeService;
    private readonly IPermissoesService _permissoesService;
    
    public CriarAgendamento(IUnitOfWork uow,
        IMapper mapper,
        IAtividadeService atividadeService,
        IAgendaService agendaService,
        IVoluntarioMinisterioService voluntarioMinisterioService,
        IDataIndisponivelService dataIndisponivelService,
        IRegistroCriacaoService registroCriacaoService,
        IAmbienteUsuarioService ambienteUsuarioService,
        IAgendamentoService agendamentoService,
        IAgendamentoAtividadeService agendamentoAtividadeService,
        IPermissoesService permissoesService) : base(uow, mapper)
    {
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

        agenda.ValidarStatus();
        
        await _agendamentoService.GaranteNaoExisteVoluntarioAgendadoAsync(agenda.Id, voluntarioMinisterio.VoluntarioId);
        await _dataIndisponivelService.GaranteExisteDataDisponivelAsync(agenda.Id, voluntarioMinisterio.VoluntarioId);
        
        var agendamento = Mapper.Map<Agendamento>(dto);
        
        await Uow.IniciarTransacaoAsync();
        await Service.AdicionarAsync(agendamento);
        
        // TODO: passar para AgendamentoAtividadeService
        #region adicionando atividades no agendamento
        if (dto.AtividadeIds != null && dto.AtividadeIds.Any())
            foreach (var atividadeId in dto.AtividadeIds)
            {
                var atividade = await _atividadeService.RecuperaGaranteExisteAsync(atividadeId);

                await _atividadeService.EnsureExistsAtividadeNoMinisterioAsync(atividade.Id, voluntarioMinisterio.MinisterioId);
                
                var agendamentoAtividade = new AgendamentoAtividade(agendamento, atividade);
                //await _uow.AgendamentoAtividades.AdicionarAsync(agendamentoAtividade);
            }
        #endregion
        await Uow.CommitTransacaoAsync();

        await Uow.IniciarTransacaoAsync();
        await _registroCriacaoService.LogAsync("agendamentos", agendamento.Id);
        await _registroCriacaoService.LogRangeAsync("agendamentos_atividades", agendamento.AgendamentoAtividades.Select(x => x.Id));
        await Uow.CommitTransacaoAsync();
        
        var agendamentoResponse = Mapper.Map<CriarAgendamentoResponse>(agendamento);

        return new CriarAgendamentoResponse();
    }
}