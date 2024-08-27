using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class GetAllVoluntarios
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllVoluntarios(
        IUnitOfWork uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<List<GetVoluntarioDto>>> ExecuteAsync(QueryParametro queryParametro)
    {
        var query = _uow.Voluntarios
            .GetAll()
            .Where(GetCondicao());
        
        var totalVoluntarios = await query
            .CountAsync(x => !x.Removido);
        
        var voluntarios = await query
            .Skip(queryParametro.Skip)
            .Take(queryParametro.Take)
            .ToListAsync();
        
        var voluntariosDto = _mapper.Map<List<GetVoluntarioDto>>(voluntarios);
        
        var respostaBase = new RespostaBase<List<GetVoluntarioDto>>(
            MensagemRepostaConstant.GetVoluntarios, voluntariosDto, totalVoluntarios);
        
        return respostaBase;
    }
    
    private static Expression<Func<Voluntario, bool>> GetCondicao()
    {
        return x => !x.Removido;
    }
}