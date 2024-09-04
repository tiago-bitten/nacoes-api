using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Ministerios;

public class GetAllMinisterios
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllMinisterios(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetMinisterioDto>>> ExecuteAsync(QueryParametro queryParametro)
    {
        var query = _uow.Ministerios
            .GetAll()
            .Where(GetCondicao());
        
        var totalMinisterios = await query.CountAsync(x => !x.Removido);
        
        var ministerios = query
            .Skip(queryParametro.Skip)
            .Take(queryParametro.Take)
            .ToListAsync();
        
        var ministeriosDto = _mapper.Map<List<GetMinisterioDto>>(ministerios);
        
        var respostaBase = new RespostaBase<List<GetMinisterioDto>>(
            RespostaBaseMensagem.GetMinisterios, ministeriosDto, totalMinisterios);
        
        return respostaBase;
    }
    
    private static Expression<Func<Ministerio, bool>> GetCondicao()
    {
        return x => !x.Removido;
    }
}