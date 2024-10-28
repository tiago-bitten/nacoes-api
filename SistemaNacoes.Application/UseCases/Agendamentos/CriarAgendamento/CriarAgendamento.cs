using AutoMapper;
using SistemaNacoes.Application.Services;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Entidades.Agendamento;
using SistemaNacoes.Domain.Entidades.DataIndisponivel;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;

public class CriarAgendamento : ICriarAgendamentoUseCase
{
        #region Ctor
        private readonly IAgendamentoService _service;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IVoluntarioService _voluntarioService;
        private readonly IMinisterioService _ministerioService;
        private readonly IAgendaService _agendaService;
        private readonly IDataIndisponivelService _dataIndisponivelService;
        private readonly IHistoricoEntidadeService _registroCriacaoService;
        private readonly IPermissoesService _permissoesService;
        
        public CriarAgendamento(IUnitOfWork uow,
            IMapper mapper,
            IAgendaService agendaService,
            IDataIndisponivelService dataIndisponivelService,
            IHistoricoEntidadeService registroCriacaoService,
            IAgendamentoService agendamentoService,
            IPermissoesService permissoesService,
            IVoluntarioService voluntarioService,
            IMinisterioService ministerioService)
        {
            _uow = uow;
            _mapper = mapper;
            _agendaService = agendaService;
            _dataIndisponivelService = dataIndisponivelService;
            _registroCriacaoService = registroCriacaoService;
            _service = agendamentoService;
            _permissoesService = permissoesService;
            _voluntarioService = voluntarioService;
            _ministerioService = ministerioService;
        }
        #endregion
    
    public async Task<CriarAgendamentoResult> ExecutarAsync(CriarAgendamentoRequest dto)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarAgendamento, "Você não possui permissão para criar agendamentos");
        
        var voluntario = await _voluntarioService.RecuperaGaranteExisteAsync(dto.VoluntarioId, "DataIndisponiveis");
        var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(dto.MinisterioId);
        var agenda = await _agendaService.RecuperaGaranteExisteAsync(dto.AgendaId);

        agenda.ValidarStatus();
        
        await _service.GaranteNaoExisteVoluntarioAgendadoAsync(agenda.Id, voluntario.Id);
        _dataIndisponivelService.GaranteExisteDataDisponivel(agenda.DataInicio, agenda.DataFinal, voluntario.DataIndisponiveis);

        var agendamento = new Agendamento(voluntario, ministerio, agenda);
        
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