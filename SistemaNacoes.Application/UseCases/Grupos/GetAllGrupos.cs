using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Grupos;

public class GetAllGrupos
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllGrupos(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<List<GetGrupoDto>>> ExecuteAsync(QueryParametro queryParametro)
    {
        var includes = GetIncludes();
        
        var query = _uow.Grupos
            .RecuperarTodos(includes)
            .Where(GetCondicao());
        
        var totalGrupos = await query.CountAsync(x => !x.Removido);
        
        var grupos = await query
            .Skip(queryParametro.Skip)
            .Take(queryParametro.Take)
            .ToListAsync();
        
        var gruposDto = _mapper.Map<List<GetGrupoDto>>(grupos);
        
        var respostaBase = new RespostaBase<List<GetGrupoDto>>(
            RespostaBaseMensagem.GetGrupos, gruposDto, totalGrupos);
        
        return respostaBase;
    }
    
    private static Expression<Func<Grupo, bool>> GetCondicao()
    {
        return x => !x.Removido;
    }
    
    private static string[] GetIncludes()
    {
        return new[]
        {
            nameof(Grupo.MinisterioPreferencial)
        };
    }
}