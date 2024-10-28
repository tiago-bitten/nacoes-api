using SistemaNacoes.Domain.Entidades.AgendamentoAtividade;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.AgendamentoAtividades.RemoverAgendamentoAtividade;

public class RemoverAgendamentoAtividade : IRemoverAgendamentoAtividadeUseCase
{
    private readonly IAgendamentoAtividadeService _service;
    private readonly IUnitOfWork _uow;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IPermissoesService _permissoesService;

    public RemoverAgendamentoAtividade(IAgendamentoAtividadeService service, IUnitOfWork uow, IHistoricoEntidadeService historicoService, IPermissoesService permissoesService)
    {
        _service = service;
        _uow = uow;
        _historicoService = historicoService;
        _permissoesService = permissoesService;
    }

    public async Task ExecutarAsync(int id)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.RemoverAgendamentoAtividade, "Você não possui permissão para remover atividades do agendamento.");

        var agendamentoAtividade = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Remover(agendamentoAtividade);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("agendamento_atividades", agendamentoAtividade.Id, "Removeu agendamento de atividade.");
        await _uow.CommitTransacaoAsync();
    }
}