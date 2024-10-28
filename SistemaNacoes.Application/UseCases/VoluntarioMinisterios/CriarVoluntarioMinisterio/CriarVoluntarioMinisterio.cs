using AutoMapper;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Entidades.Ministerio;
using SistemaNacoes.Domain.Entidades.Voluntario;
using SistemaNacoes.Domain.Entidades.VoluntarioMinisterio;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio;

public class CriarVoluntarioMinisterio : ICriarVoluntarioMinisterioUseCase
{
    #region Ctor
    private readonly IVoluntarioMinisterioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IVoluntarioService _voluntarioService;
    private readonly IMinisterioService _ministerioService;

    public CriarVoluntarioMinisterio(IVoluntarioMinisterioService service, IUnitOfWork uow, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService, IVoluntarioService voluntarioService, IMinisterioService ministerioService, IMapper mapper)
    {
        _service = service;
        _uow = uow;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
        _voluntarioService = voluntarioService;
        _ministerioService = ministerioService;
        _mapper = mapper;
    }
    #endregion
    
    public async Task<CriarVoluntarioMinisterioResult> ExecutarAsync(CriarVoluntarioMinisterioRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarVoluntarioMinisterio, "Você não tem permissão para vincular.");
        
        var voluntario = await _voluntarioService.RecuperaGaranteExisteAsync(request.VoluntarioId);
        var ministerios = await _ministerioService.RecuperaGaranteExisteVariosAsync(request.MinisteriosId);

        var voluntarioMinisterios = new List<VoluntarioMinisterio>();
        
        await _uow.IniciarTransacaoAsync();
        foreach (var ministerio in ministerios)
        {
            await _service.GaranteNaoExisteVoluntarioNoMinisterio(voluntario.Id, ministerio.Id);

            var voluntarioMinisterio = new VoluntarioMinisterio(voluntario, ministerio);
            voluntarioMinisterios.Add(voluntarioMinisterio);
        }
        await _service.AdicionarVariosAsync(voluntarioMinisterios);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("voluntarios", voluntario.Id, "Vinculado a ministérios.");
        await _historicoService.RegistrarVariosAsync("ministerios", ministerios.Select(x => x.Id).ToList(), "Vinculado a voluntário.");
        await _uow.CommitTransacaoAsync();

        var result = _mapper.Map<CriarVoluntarioMinisterioResult>(voluntarioMinisterios);

        return result;
    }
}