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

    public async Task<RespostaBase<GetVoluntariosNoGrupoDto>> ExecuteAsync(int grupoId)
    {
        var includes = GetIncludes();
        
        var grupo = await _grupoService.GetAndEnsureExistsAsync(grupoId, includes);

        var voluntariosNoGrupo = grupo.GrupoVoluntarios
            .Where(x => !x.Removido)
            .Select(x => x.Voluntario)
            .OrderBy(x => x.Nome)
            .ToList();

        var totalVoluntariosNoGrupo = voluntariosNoGrupo.Count;
        
        var grupoDto = _mapper.Map<GetGrupoDto>(grupo);
        var simpVoluntariosDto = _mapper.Map<List<GetSimpVoluntarioDto>>(voluntariosNoGrupo);

        var voluntariosNoGrupoDto = new GetVoluntariosNoGrupoDto
        {
            Grupo = grupoDto,
            Voluntarios = simpVoluntariosDto
        };
        
        return new RespostaBase<GetVoluntariosNoGrupoDto>(
            MensagemRepostasConstant.GetVoluntariosNoGrupo, voluntariosNoGrupoDto, totalVoluntariosNoGrupo);
    }
    
    private static string[] GetIncludes()
    {
        return new[]
        {
            nameof(Grupo.GrupoVoluntarios),
            nameof(Grupo.MinisterioPreferencial),
            $"{nameof(Grupo.GrupoVoluntarios)}.{nameof(GrupoVoluntario.Voluntario)}",
        };
    }
}
