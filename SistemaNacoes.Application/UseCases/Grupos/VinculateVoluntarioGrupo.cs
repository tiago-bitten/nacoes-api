using AutoMapper;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Grupos;

public class VinculateVoluntarioGrupo
{
    
    #region ctor
    private readonly IUnitOfWork _uow;
    private readonly IVoluntarioService _voluntarioService;
    private readonly IServiceBase<Grupo> _grupoService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IRegistroCriacaoService _registroCriacaoService;

    public VinculateVoluntarioGrupo(IUnitOfWork uow, IVoluntarioService voluntarioService, IServiceBase<Grupo> grupoService, IRegistroCriacaoService registroCriacaoService, IAmbienteUsuarioService ambienteUsuarioService)
    {
        _uow = uow;
        _voluntarioService = voluntarioService;
        _grupoService = grupoService;
        _registroCriacaoService = registroCriacaoService;
        _ambienteUsuarioService = ambienteUsuarioService;
    }
    #endregion

    public async Task<RespostaBase<dynamic>> ExecuteAsync(VinculateVoluntarioGrupoDto dto)
    {
        var voluntarioIncludes = new[] { nameof(Voluntario.GrupoVoluntarios) };
        
        var voluntario = await _voluntarioService.GetAndEnsureExistsAsync(dto.VoluntarioId, includes: voluntarioIncludes);
        var grupo = await _grupoService.GetAndEnsureExistsAsync(dto.GrupoId);

        var existsVoluntarioGrupo = voluntario.GrupoVoluntarios.Any(x => !x.Removido);
        
        if (existsVoluntarioGrupo)
            throw new Exception(MensagemErroConstant.VoluntarioJaPossuiGrupo);
        
        var grupoVoluntario = new GrupoVoluntario(grupo, voluntario);
        
        await _uow.GrupoVoluntarios.AddAsync(grupoVoluntario);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(
            RespostaBaseMensagem.VinculateVoluntarioGrupo);
        
        return respostaBase;
    }
}