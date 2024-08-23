using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios;

public class GetAllVoluntarioMinisterios
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllVoluntarioMinisterios(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetSimpVoluntarioMinisterioDto>>> ExecuteAsync(QueryParametro queryParametro)
    {
        var includes = GetIncludes();
        
        var query = _uow.VoluntarioMinisterios
            .GetAll(includes)
            .Where(GetCondicao());
        
        var totalVoluntarioMinisterios = await query.CountAsync(x => x.Ativo);
        
        var voluntarioMinisterios = await query
            .Skip(queryParametro.Skip)
            .Take(queryParametro.Take)
            .ToListAsync();
        
        var voluntarioMinisteriosDto = _mapper.Map<List<GetSimpVoluntarioMinisterioDto>>(voluntarioMinisterios);

        var respostaBase = new RespostaBase<List<GetSimpVoluntarioMinisterioDto>>(
            MensagemRepostasConstant.GetVoluntariosMinisterios, voluntarioMinisteriosDto, totalVoluntarioMinisterios);
        
        return respostaBase;
    }
    
    private static Expression<Func<VoluntarioMinisterio, bool>> GetCondicao()
    {
        return x => x.Ativo;
    }
    
    private static string[] GetIncludes()
    {
        return new[]
        {
            nameof(VoluntarioMinisterio.Voluntario),
            nameof(VoluntarioMinisterio.Ministerio)
        };
    }
}