using SistemaNacoes.Application.UseCases.AgendamentoAtividade.CriarAgendamentoAtividade;
using SistemaNacoes.Application.UseCases.AgendamentoAtividades.CriarAgendamentoAtividade.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.AgendamentoAtividades.CriarAgendamentoAtividade;

public class CriarAgendamentoAtividade : ICriarAgendamentoAtividadeUseCase
{
    private readonly IUnitOfWork _uow;
    private readonly IAgendamentoAtividadeService _service;
    private readonly IAgendamentoService _agendamentoService;
    private readonly IAtividadeService _atividadeService;

    public CriarAgendamentoAtividade(IUnitOfWork uow, IAgendamentoAtividadeService service, IAtividadeService atividadeService, IAgendamentoService agendamentoService)
    {
        _uow = uow;
        _service = service;
        _atividadeService = atividadeService;
        _agendamentoService = agendamentoService;
    }

    public async Task<CriarAgendamentoAtividadeResult> ExecutarAsync(CriarAgendamentoAtividadeRequest request)
    {
        var agendamento = await _agendamentoService.RecuperaGaranteExisteAsync(request.AgendamentoId);

        await _uow.IniciarTransacaoAsync();
        foreach (var atividadeId in request.AtividadeIds)
        {
            var atividade = await _atividadeService.RecuperaGaranteExisteAsync(atividadeId);
            
            await _service.GaranteNaoExisteAtividadeNoAgendamentoAsync(agendamento.Id, atividade.Id);

            var agendamentoAtividade = new Domain.Entidades.AgendamentoAtividade(agendamento, atividade);

            await _service.AdicionarAsync(agendamentoAtividade);
        }
        await _uow.CommitTransacaoAsync();

        var response = new CriarAgendamentoAtividadeResult();

        return response;
    }
}