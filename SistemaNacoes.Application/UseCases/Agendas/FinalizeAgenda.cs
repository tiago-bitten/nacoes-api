using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas;

public class FinalizeAgenda
{
    private readonly IUnitOfWork _uow;
    private readonly IServiceBase<Agenda> _agendaService;

    public FinalizeAgenda(IServiceBase<Agenda> agendaService, IUnitOfWork uow)
    {
        _agendaService = agendaService;
        _uow = uow;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(FinalizeAgendaDto dto)
    {
        var agenda = await _agendaService.RecuperaGaranteExisteAsync(dto.Id);
        
        if (agenda.Finalizado)
            throw new Exception(MensagemErroConstant.AgendaJaFinalizada);

        agenda.Finalize();
        _uow.Agendas.Update(agenda);
        await _uow.CommitAsync();

        var respostaBase = new RespostaBase<dynamic>(
            RespostaBaseMensagem.FinalizeAgenda);

        return respostaBase; 
    }
}