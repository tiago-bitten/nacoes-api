using AutoMapper;
using SistemaNacoes.Application.UseCases.GrupoVoluntarios.CriarGrupoVoluntario.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Grupo;
using SistemaNacoes.Domain.Entidades.GrupoVoluntario;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.GrupoVoluntarios.CriarGrupoVoluntario;

public class CriarGrupoVoluntario : ICriarGrupoVoluntarioUseCase
{
    private readonly IGrupoVoluntarioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IPermissoesService _permissoesService;
    private readonly IGrupoService _grupoService;
    private readonly IVoluntarioService _voluntarioService;

    public CriarGrupoVoluntario(IGrupoVoluntarioService service, IUnitOfWork uow, IHistoricoEntidadeService historicoService, IPermissoesService permissoesService, IMapper mapper, IGrupoService grupoService, IVoluntarioService voluntarioService)
    {
        _service = service;
        _uow = uow;
        _historicoService = historicoService;
        _permissoesService = permissoesService;
        _mapper = mapper;
        _grupoService = grupoService;
        _voluntarioService = voluntarioService;
    }

    public async Task<CriarGrupoVoluntarioResult> ExecutarAsync(CriarGrupoVoluntarioRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarVoluntarioGrupo, "Você não tem permissão para criar um grupo de voluntários.");
        
        var grupo = await _grupoService.RecuperaGaranteExisteAsync(request.GrupoId);
        var voluntarios = await _voluntarioService.RecuperaGaranteExisteVariosAsync(request.VoluntarioIds);
        
        var grupoVoluntarios = voluntarios
            .Select(voluntario => new GrupoVoluntario(grupo, voluntario))
            .ToList();

        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarVariosAsync(grupoVoluntarios);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarVariosAsync("grupo_voluntarios", grupoVoluntarios.Select(x => x.Id).ToList(), "Voluntário vinculado ao grupo.");
        await _uow.CommitTransacaoAsync();
        
        var result = _mapper.Map<CriarGrupoVoluntarioResult>(grupoVoluntarios);
        
        return result;
    }
}