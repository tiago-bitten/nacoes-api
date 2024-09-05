using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class VinculateAgendamentoAtividade
{
    #region ctor
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IAtividadeService _atividadeService;
    private readonly IServiceBase<Agendamento> _agendamentoService;

    public VinculateAgendamentoAtividade(IUnitOfWork uow, IMapper mapper, IAtividadeService atividadeService, IServiceBase<Agendamento> agendamentoService)
    {
        _uow = uow;
        _mapper = mapper;
        _atividadeService = atividadeService;
        _agendamentoService = agendamentoService;
    }
    #endregion
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(VinculateAgendamentoAtividadeDto dto)
    {
        var atividade = await _atividadeService.GetAndEnsureExistsAsync(dto.AtividadeId);
        var agendamento = await _agendamentoService.GetAndEnsureExistsAsync(dto.AgendamentoId);

        await _atividadeService.ensure(atividade.Id, agendamento.Id);        
        await _atividadeService.EnsureExistsAtividadeNoMinisterioAsync(atividade.Id, agendamento.MinisterioId);
        
        var agendamentoAtividade = new AgendamentoAtividade(agendamento, atividade);
        
        await _uow.AgendamentoAtividades.AddAsync(agendamentoAtividade);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(
            RespostaBaseMensagem.VinculateAtividadeAgendamento);
        
        return respostaBase;
    }
}