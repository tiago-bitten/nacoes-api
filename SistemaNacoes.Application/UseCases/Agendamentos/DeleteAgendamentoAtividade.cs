using AutoMapper;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

// todo: passar para pasta AgendamentoAtividade
public class DeleteAgendamentoAtividade
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IAgendamentoAtividadeService _agendamentoAtividadeService;

    public DeleteAgendamentoAtividade(IUnitOfWork uow, IMapper mapper, IAgendamentoAtividadeService agendamentoAtividadeService)
    {
        _uow = uow;
        _mapper = mapper;
        _agendamentoAtividadeService = agendamentoAtividadeService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int agendamentoId, int atividadeId)
    {
        var agendamentoAtividade = await _agendamentoAtividadeService.RecuperaGaranteExisteAsync(agendamentoId);
        
        agendamentoAtividade.GaranteExiste();
        
        await _agendamentoAtividadeService.
        await _uow.AgendamentoAtividades;
        
        var respostaBase = new RespostaBase<dynamic>(
            RespostaBaseMensagem.DeleteAgendamentoAtividade);
        
        return respostaBase;
    }
}