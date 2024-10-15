using SistemaNacoes.Application.UseCases.AgendamentoAtividade.CriarAgendamentoAtividade;
using SistemaNacoes.Application.UseCases.AgendamentoAtividades.CriarAgendamentoAtividade.Dtos;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.AgendamentoAtividades.CriarAgendamentoAtividade;

public class CriarAgendamentoAtividade : ICriarAgendamentoAtividadeUseCase
{
    private readonly IUnitOfWork _uow;
    private readonly IAgendamentoAtividadeService _service;
    private readonly IAgendamentoService _agendamentoService;
    private readonly IAtividadeService _atividadeService;
    private readonly IHistoricoEntidadeService _historicoService;

    public CriarAgendamentoAtividade(IUnitOfWork uow, IAgendamentoAtividadeService service, IAtividadeService atividadeService, IAgendamentoService agendamentoService, IHistoricoEntidadeService historicoService)
    {
        _uow = uow;
        _service = service;
        _atividadeService = atividadeService;
        _agendamentoService = agendamentoService;
        _historicoService = historicoService;
    }

    public async Task<CriarAgendamentoAtividadeResult> ExecutarAsync(CriarAgendamentoAtividadeRequest request)
    {
        var agendamento = await _agendamentoService.RecuperaGaranteExisteAsync(request.AgendamentoId);

        var agendamentoAtividades = new List<Domain.Entidades.AgendamentoAtividade>();
        
        await _uow.IniciarTransacaoAsync();
        foreach (var atividadeId in request.AtividadeIds)
        {
            var atividade = await _atividadeService.RecuperaGaranteExisteAsync(atividadeId);
            
            await _service.GaranteNaoExisteAtividadeNoAgendamentoAsync(agendamento.Id, atividade.Id);

            var agendamentoAtividade = new Domain.Entidades.AgendamentoAtividade(agendamento, atividade);
            agendamentoAtividades.Add(agendamentoAtividade);
        }
        await _service.AdicionarVariosAsync(agendamentoAtividades);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarVariosAsync("agendamento_atividades", agendamentoAtividades.Select(x => x.Id), "Vinculou atividade ao agendamento.");
        await _uow.CommitTransacaoAsync();
        
        var response = new CriarAgendamentoAtividadeResult();

        return response;
    }
}