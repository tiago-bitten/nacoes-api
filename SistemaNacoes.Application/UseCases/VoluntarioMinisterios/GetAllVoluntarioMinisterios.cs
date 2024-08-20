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
    
    public async Task<RespostaBase<List<GetSimpVoluntarioMinisterioDto>>> ExecuteAsync(QueryParametro query)
    {
        var includes = new[]
        {
            nameof(VoluntarioMinisterio.Voluntario),
            nameof(VoluntarioMinisterio.Ministerio)
        };
        
        var totalVoluntarioMinisterios = await _uow.VoluntarioMinisterios
            .GetAll(includes)
            .CountAsync(x => x.Ativo);
        
        var voluntarioMinisterios = await _uow.VoluntarioMinisterios
            .GetAll(includes)
            .Where(x => x.Ativo)
            .Skip(query.Skip)
            .Take(query.Take)
            .ToListAsync();
        
        var voluntarioMinisteriosDto = _mapper.Map<List<GetSimpVoluntarioMinisterioDto>>(voluntarioMinisterios);

        var respostaBase = new RespostaBase<List<GetSimpVoluntarioMinisterioDto>>(
            MensagemRepostasConstant.GetVoluntariosMinisterios, voluntarioMinisteriosDto, totalVoluntarioMinisterios);
        
        return respostaBase;
    }
}