using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Agendamentos;

public class GetAllAgendamentos
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllAgendamentos(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<CriarAgendamentoResponse>>> ExecuteAsync(QueryParametro queryParametro)
    {
        var query = _uow.Agendamentos
            .RecuperarTodos(GetIncludes())
            .Where(GetCondicao());
        
        var totalAgendamentos = await query.CountAsync();
        
        var agendamentos = await query
            .Skip(queryParametro.Skip)
            .Take(queryParametro.Take)
            .ToListAsync();
        
        var agendamentosDto = _mapper.Map<List<CriarAgendamentoResponse>>(agendamentos);
        
        var respostaBase = new RespostaBase<List<CriarAgendamentoResponse>>(
            RespostaBaseMensagem.GetAgendamentos, agendamentosDto, totalAgendamentos);
        
        return respostaBase;
    }
    
    private static Expression<Func<Agendamento, bool>> GetCondicao()
    {
        return x => !x.Removido;
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