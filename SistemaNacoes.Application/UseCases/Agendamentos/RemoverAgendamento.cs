using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class RemoverAgendamento
{
    private readonly IUnitOfWork _uow;
    private readonly IServiceBase<Agendamento> _agendamentoService;

    public RemoverAgendamento(IUnitOfWork uow, IServiceBase<Agendamento> agendamentoService)
    {
        _uow = uow;
        _agendamentoService = agendamentoService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var agendamento = await _agendamentoService.RecuperaGaranteExisteAsync(id);
        
        _agendamentoService.Remover(agendamento);
        await _uow.CommitAsync();

        var respostaBase = new RespostaBase<dynamic>(
            RespostaBaseMensagem.DeleteAgendamento);
        
        return respostaBase;
    }
}