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

    public async Task<RespostaBase<List<GetGrupoDto>>> ExecuteAsync(QueryParametro query)
    {
        var includes = new[]
        {
            nameof(Grupo.MinisterioPreferencial)
        };
        
        var totalGrupos = await _uow.Grupos
            .GetAll(includes)
            .CountAsync(x => !x.Removido);
        
        var grupos = await _uow.Grupos
            .GetAll(includes)
            .Where(x => !x.Removido)
            .Skip(query.Skip)
            .Take(query.Take)
            .ToListAsync();
        
        var gruposDto = _mapper.Map<List<GetGrupoDto>>(grupos);
        
        var respostaBase = new RespostaBase<List<GetGrupoDto>>(MensagemRepostasConstant.GetGrupos, gruposDto, totalGrupos);
        
        return respostaBase;
    }
}