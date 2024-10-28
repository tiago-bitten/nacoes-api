using AutoMapper;
using SistemaNacoes.Application.UseCases.Grupos.CriarGrupo.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Grupo;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Grupos.CriarGrupo;

public class CriarGrupo: ICriarGrupoUseCase
{
    private readonly IGrupoService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IPermissoesService _permissoesService;
    private readonly IMinisterioService _ministerioService;

    public CriarGrupo(IGrupoService service, IUnitOfWork uow, IMapper mapper, IHistoricoEntidadeService historicoService, IPermissoesService permissoesService, IMinisterioService ministerioService)
    {
        _service = service;
        _uow = uow;
        _mapper = mapper;
        _historicoService = historicoService;
        _permissoesService = permissoesService;
        _ministerioService = ministerioService;
    }

    public async Task<CriarGrupoResult> ExecutarAsync(CriarGrupoRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarGrupo, "Você não tem permissão para criar um grupo.");
        
        var grupo = _mapper.Map<Grupo>(request);

        if (request.MinisterioPreferencialId.HasValue)
        {
            var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(request.MinisterioPreferencialId.Value);
            grupo.MinisterioPreferencial = ministerio;
        }

        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(grupo);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("grupos", grupo.Id, "Criou grupo.");
        await _uow.CommitTransacaoAsync();
        
        var result = _mapper.Map<CriarGrupoResult>(grupo);
        
        return result;
    }
}