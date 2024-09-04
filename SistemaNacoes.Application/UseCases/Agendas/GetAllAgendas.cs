using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Agendas;

public class GetAllAgendas
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllAgendas(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetAgendaDto>>> ExecuteAsync(int mes, int ano)
    {
        var query = _uow.Agendas
            .GetAll()
            .Where(GetCondicao(mes, ano));

        var totalAgendas = await query.CountAsync();
        var agendas = await query.ToListAsync();
        
        var agendasDto = _mapper.Map<List<GetAgendaDto>>(agendas);
        
        var respostaBase = new RespostaBase<List<GetAgendaDto>>(
            RespostaBaseMensagem.GetAgendas, agendasDto, totalAgendas);
        
        return respostaBase;
    }
    
    private static Expression<Func<Agenda, bool>> GetCondicao(int mes, int ano)
    {
        return x => x.Ativo && x.DataInicio.Month == mes && x.DataInicio.Year == ano;
    }
}