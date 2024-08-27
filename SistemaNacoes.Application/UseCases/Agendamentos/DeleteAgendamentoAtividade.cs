using AutoMapper;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

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
        var agendamentoAtividade = await _agendamentoAtividadeService.GetAndEnsureExistsAsync(agendamentoId, atividadeId);
        
        if (agendamentoAtividade.Removido)
            throw new Exception(MensagemErroConstant.AgendamentoAtividadeJaRemovido);
        
        _uow.AgendamentoAtividades.SoftDelete(agendamentoAtividade);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(MensagemRepostaConstant.DeleteAgendamentoAtividade);
        
        return respostaBase;
    }
}