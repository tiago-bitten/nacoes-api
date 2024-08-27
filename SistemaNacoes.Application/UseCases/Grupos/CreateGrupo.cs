using System.Runtime.CompilerServices;
using AutoMapper;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Grupos;

public class CreateGrupo
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IVoluntarioService _voluntarioService;
    
    public CreateGrupo(IUnitOfWork uow, IMapper mapper, IVoluntarioService voluntarioService)
    {
        _uow = uow;
        _mapper = mapper;
        _voluntarioService = voluntarioService;
    }
    
    public async Task<RespostaBase<GetGrupoDto>> ExecuteAsync(CreateGrupoDto dto)
    {
        var existsGrupo = await _uow.Grupos
            .FindAsync(x => x.Nome.ToLower() == dto.Nome.ToLower() && !x.Removido);
        
        if (existsGrupo != null)
            throw new Exception(MensagemErroConstant.GrupoJaExiste);
        
        var grupo = _mapper.Map<Grupo>(dto);
        
        await _uow.Grupos.AddAsync(grupo);
        
        if (dto.VoluntarioIds != null && dto.VoluntarioIds.Any())
            foreach (var voluntarioId in dto.VoluntarioIds)
            {
                var includes = new[] { nameof(Voluntario.GrupoVoluntarios) };
                
                var voluntario = await _voluntarioService.GetAndEnsureExistsAsync(voluntarioId, includes);

                if (voluntario.GrupoVoluntarios.Any(x => !x.Removido))
                {
                    _uow.RollBack();
                    throw new Exception(MensagemErroConstant.VoluntarioJaPossuiGrupo);
                }
                
                var grupoVoluntario = new GrupoVoluntario(grupo, voluntario);
                await _uow.GrupoVoluntarios.AddAsync(grupoVoluntario);
            }
        
        await _uow.CommitAsync();

        var grupoDto = _mapper.Map<GetGrupoDto>(grupo);
        
        var respostaBase = new RespostaBase<GetGrupoDto>(MensagemRepostaConstant.CreateGrupo, grupoDto);
        
        return respostaBase;
    }
}