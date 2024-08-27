using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class VinculateAgendamentoAtividade
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IServiceBase<Atividade> _atividadeService;
    private readonly IServiceBase<Agendamento> _agendamentoService;

    public VinculateAgendamentoAtividade(IUnitOfWork uow, IMapper mapper, IServiceBase<Atividade> atividadeService, IServiceBase<Agendamento> agendamentoService)
    {
        _uow = uow;
        _mapper = mapper;
        _atividadeService = atividadeService;
        _agendamentoService = agendamentoService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(VinculateAgendamentoAtividadeDto dto)
    {
        var atividade = await _atividadeService.GetAndEnsureExistsAsync(dto.AtividadeId);

        // var includes = GetIncludes();
        var agendamento = await _agendamentoService.GetAndEnsureExistsAsync(dto.AgendamentoId);
        
        // Em memória
        /*var existsAtividade = agendamento.AgendamentoAtividades
            .Any(x => x.AtividadeId == atividade.Id && !x.Removido);*/
        
        // Em banco
        var existsAtividade = await _uow.Atividades
            .GetAll()
            .AnyAsync(x => x.Id == atividade.Id
                           && x.AgendamentoAtividades.Any(at => at.AgendamentoId == agendamento.Id && !at.Removido)
                           && !x.Removido);
        
        if (existsAtividade)
            throw new Exception(MensagemErroConstant.AtividadeJaVinculadaAoAgendamento);
        
        // Em memória
        /*var existsAtividadeNoMinisterio = agendamento.Ministerio.Atividades
            .Any(x => x.Id == atividade.Id && !x.Removido);*/
        
        // Em banco
        var existsAtividadeNoMinisterio = await _uow.Atividades
            .GetAll()
            .AnyAsync(x => x.Id == atividade.Id 
                           && x.MinisterioId == agendamento.MinisterioId 
                           && !x.Removido);
        
        if (!existsAtividadeNoMinisterio)
            throw new Exception(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
        
        var agendamentoAtividade = new AgendamentoAtividade(agendamento, atividade);
        
        await _uow.AgendamentoAtividades.AddAsync(agendamentoAtividade);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(MensagemRepostaConstant.VinculateAtividadeAgendamento);
        
        return respostaBase;
    }
    
    private static string[] GetIncludes()
    {
        return new[]
        {
            nameof(Agendamento.Voluntario),
            nameof(Agendamento.Ministerio),
            $"{nameof(Agendamento.AgendamentoAtividades)}.{nameof(AgendamentoAtividade.Atividade)}"
        };
    }
}