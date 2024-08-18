﻿using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class VinculateAtividadeAgendamento
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IServiceBase<Atividade> _atividadeService;
    private readonly IServiceBase<Agendamento> _agendamentoService;

    public VinculateAtividadeAgendamento(IUnitOfWork uow, IMapper mapper, IServiceBase<Atividade> atividadeService, IServiceBase<Agendamento> agendamentoService)
    {
        _uow = uow;
        _mapper = mapper;
        _atividadeService = atividadeService;
        _agendamentoService = agendamentoService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(VinculateAtividadeAgendamentoDto dto)
    {
        var atividade = await _atividadeService.GetAndEnsureExistsAsync(dto.AtividadeId);
        var agendamento = await _agendamentoService.GetAndEnsureExistsAsync(dto.AgendamentoId);
        
        var existsAtividade = agendamento.AgendamentoAtividades
            .Any(x => x.AtividadeId == atividade.Id && !x.Removido);
        
        if (existsAtividade)
            throw new Exception(MensagemErrosConstant.AtividadeJaVinculadaAoAgendamento);
        
        var existsAtividadeMinisterio = agendamento.Ministerio.Atividades
            .Any(x => x.Id == atividade.Id && !x.Removido);

        if (!existsAtividadeMinisterio)
            throw new Exception(MensagemErrosConstant.AtividadeNaoPertenceAoMinisterio);
        
        var agendamentoAtividade = new AgendamentoAtividade(agendamento, atividade);
        
        await _uow.AgendamentoAtividades.AddAsync(agendamentoAtividade);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(MensagemRepostasConstant.VinculateAtividadeAgendamento);
        
        return respostaBase;
    }
}