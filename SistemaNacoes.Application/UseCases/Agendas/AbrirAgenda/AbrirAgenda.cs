using AutoMapper;
using SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda.Dtos;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda;

public class AbrirAgenda : IAbrirAgendaUseCase
{
    #region Ctor
    private readonly IAgendaService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;

    public AbrirAgenda(IAgendaService service, IUnitOfWork uow, IPermissoesService permissoesService, IMapper mapper, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _permissoesService = permissoesService;
        _mapper = mapper;
        _historicoService = historicoService;
    }
    #endregion

    public async Task<AbrirAgendaResult> ExecutarAsync(AbrirAgendaRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.AbrirAgenda, "Você não tem permissão para abrir uma agenda.");
        
        var dataFinal = request.DataInicio.AddMinutes(request.Duracao);
        
        if (dataFinal <= request.DataInicio)
            throw new NacoesAppException("A duracao da agenda deve ser maior que 0 minutos.");

        var agenda = _mapper.Map<Agenda>(request);
        
        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(agenda);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("agendas", agenda.Id, "Abriu agenda.");
        await _uow.CommitTransacaoAsync();
        
        var result = _mapper.Map<AbrirAgendaResult>(agenda);

        return result;
    }
}