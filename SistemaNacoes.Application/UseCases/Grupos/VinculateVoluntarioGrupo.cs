using AutoMapper;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Grupos;

public class VinculateVoluntarioGrupo
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IVoluntarioService _voluntarioService;
    private readonly IServiceBase<Grupo> _grupoService;
    

    public VinculateVoluntarioGrupo(IUnitOfWork uow, IMapper mapper, IVoluntarioService voluntarioService, IServiceBase<Grupo> grupoService)
    {
        _uow = uow;
        _mapper = mapper;
        _voluntarioService = voluntarioService;
        _grupoService = grupoService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(VinculateVoluntarioGrupoDto dto)
    {
        var voluntario = await _voluntarioService.GetAndEnsureExistsAsync(dto.VoluntarioId);
        var grupo = await _grupoService.GetAndEnsureExistsAsync(dto.GrupoId);
        
        if (voluntario.GrupoVoluntarios.Any(x => !x.Removido))
            throw new Exception(MensagemErrosConstant.VoluntarioJaPossuiGrupo);
        
        var grupoVoluntario = new GrupoVoluntario(grupo, voluntario);
        
        await _uow.GrupoVoluntarios.AddAsync(grupoVoluntario);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(MensagemRepostasConstant.VinculateVoluntarioGrupo);
        
        return respostaBase;
    }
}