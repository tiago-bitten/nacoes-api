using AutoMapper;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Extensions;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Grupos;

public class CreateGrupo
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IVoluntarioService _voluntarioService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IRegistroCriacaoService _registroCriacaoService;
    
    public CreateGrupo(IUnitOfWork uow, IMapper mapper, IVoluntarioService voluntarioService, IAmbienteUsuarioService ambienteUsuarioService, IRegistroCriacaoService registroCriacaoService)
    {
        _uow = uow;
        _mapper = mapper;
        _voluntarioService = voluntarioService;
        _ambienteUsuarioService = ambienteUsuarioService;
        _registroCriacaoService = registroCriacaoService;
    }
    
    public async Task<RespostaBase<GetGrupoDto>> ExecuteAsync(CreateGrupoDto dto)
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();

        if (!usuarioLogado.HasPermission(EPermissoes.CREATE_GRUPO))
            throw new Exception(MensagemErroConstant.SemPermissaoParaCriarGrupo);
        
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
                
                var voluntario = await _voluntarioService.RecuperaGaranteExisteAsync(voluntarioId, includes: includes);

                if (voluntario.GrupoVoluntarios.Any(x => !x.Removido))
                {
                    _uow.RollBack();
                    throw new Exception(MensagemErroConstant.VoluntarioJaPossuiGrupo);
                }
                
                var grupoVoluntario = new GrupoVoluntario(grupo, voluntario);
                await _uow.GrupoVoluntarios.AddAsync(grupoVoluntario);
            }
        
        await _uow.CommitAsync();

        await _registroCriacaoService.LogAsync("grupos", grupo.Id);
        await _registroCriacaoService.LogRangeAsync("grupos_voluntarios", grupo.GrupoVoluntarios.Select(x => x.Id));

        var grupoDto = _mapper.Map<GetGrupoDto>(grupo);
        
        var respostaBase = new RespostaBase<GetGrupoDto>(
            RespostaBaseMensagem.CreateGrupo, grupoDto);
        
        return respostaBase;
    }
}