using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Dtos.GrupoVoluntarios;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.GrupoVoluntarios;

public class GetVoluntariosNoGrupo
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IServiceBase<Grupo> _grupoService;

    public GetVoluntariosNoGrupo(IUnitOfWork uow, IMapper mapper, IServiceBase<Grupo> grupoService)
    {
        _uow = uow;
        _mapper = mapper;
        _grupoService = grupoService;
    }

    // TODO: Refatorar adicionando a lógica de listagem igual a de outras entidades
    public async Task<RespostaBase<GetVoluntariosNoGrupoDto>> ExecuteAsync(int grupoId)
    {
        var grupoIncludes = GetGrupoIncludes();
        var grupoVolutariosIncludes = GetGrupoVoluntariosIncludes();
        
        var grupo = await _grupoService.RecuperaGaranteExisteAsync(grupoId, includes: grupoIncludes);

        var query = _uow.GrupoVoluntarios
            .RecuperarTodos(grupoVolutariosIncludes)
            .Where(GetCondicao(grupo.Id))
            .Select(x => x.Voluntario)
            .OrderBy(x => x.Nome);
        
        var totalVoluntariosNoGrupo = await query.CountAsync();
        var voluntariosNoGrupo = await query.ToListAsync();
        
        var grupoDto = _mapper.Map<GetGrupoDto>(grupo);
        var simpVoluntariosDto = _mapper.Map<List<GetSimpVoluntarioDto>>(voluntariosNoGrupo);

        var voluntariosNoGrupoDto = new GetVoluntariosNoGrupoDto()
        {
            Grupo = grupoDto,
            Voluntarios = simpVoluntariosDto
        };
        
        var respostaBase = new RespostaBase<GetVoluntariosNoGrupoDto>(
            RespostaBaseMensagem.GetVoluntariosNoGrupo, voluntariosNoGrupoDto, totalVoluntariosNoGrupo);
        
        return respostaBase;

    }
    
    private static Expression<Func<GrupoVoluntario, bool>> GetCondicao(int grupoId)
    {
        return x => !x.Removido && !x.Voluntario.Removido && x.GrupoId == grupoId;
    }
    
    private static string[] GetGrupoIncludes()
    {
        return new[]
        {
            nameof(Grupo.MinisterioPreferencial),
        };
    }
    
    private static string[] GetGrupoVoluntariosIncludes()
    {
        return new[]
        {
            nameof(GrupoVoluntario.Voluntario)
        };
    }
}