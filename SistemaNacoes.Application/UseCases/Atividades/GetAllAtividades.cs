using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Atividades;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Atividades;

public class GetAllAtividades
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllAtividades(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetAtividadeDto>>> ExecuteAsync(QueryParametro queryParametro)
    {
        var query = _uow.Atividades
            .GetAll()
            .Where(GetCondicao());
        
        var totalAtividades = await query.CountAsync();
        
        var atividades = await query
            .Skip(queryParametro.Skip)
            .Take(queryParametro.Take)
            .ToListAsync();
        
        var atividadesDto = _mapper.Map<List<GetAtividadeDto>>(atividades);
        
        var respostaBase = new RespostaBase<List<GetAtividadeDto>>(MensagemRepostaConstant.GetAtividades, atividadesDto, totalAtividades);
        
        return respostaBase;
    }

    private static Expression<Func<Atividade, bool>> GetCondicao()
    {
        return x => !x.Removido;
    }
}