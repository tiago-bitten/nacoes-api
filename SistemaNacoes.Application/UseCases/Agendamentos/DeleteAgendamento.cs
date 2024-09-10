using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class DeleteAgendamento
{
    private readonly IUnitOfWork _uow;
    private readonly IServiceBase<Agendamento> _agendamentoService;

    public DeleteAgendamento(IUnitOfWork uow, IServiceBase<Agendamento> agendamentoService)
    {
        _uow = uow;
        _agendamentoService = agendamentoService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var agendamento = await _agendamentoService.GetAndEnsureExistsAsync(id);
        
        _uow.Agendamentos.SoftDelete(agendamento);
        await _uow.CommitAsync();

        var respostaBase = new RespostaBase<dynamic>(
            RespostaBaseMensagem.DeleteAgendamento);
        
        return respostaBase;
    }
}