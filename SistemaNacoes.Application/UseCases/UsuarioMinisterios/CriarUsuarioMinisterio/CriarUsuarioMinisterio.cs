using AutoMapper;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios.CriarUsuarioMinisterio.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Ministerio;
using SistemaNacoes.Domain.Entidades.Usuario;
using SistemaNacoes.Domain.Entidades.UsuarioMinisterio;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.UsuarioMinisterios.CriarUsuarioMinisterio;

public class CriarUsuarioMinisterio : ICriarUsuarioMinisterioUseCase
{
    #region Ctor
    private readonly IUsuarioMinisterioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IUsuarioService _usuarioService;
    private readonly IMinisterioService _ministerioService;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;

    public CriarUsuarioMinisterio(IUsuarioMinisterioService service, IUnitOfWork uow, IMapper mapper, IUsuarioService usuarioService, IMinisterioService ministerioService, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _mapper = mapper;
        _usuarioService = usuarioService;
        _ministerioService = ministerioService;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
    }
    #endregion

    public async Task<CriarUsuarioMinisterioResult> ExecutarAsync(CriarUsuarioMinisterioRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarUsuarioMinisterio, "Você não tem permissão para vincular um usuário em um ministério.");
        
        var usuario = await _usuarioService.RecuperaGaranteExisteAsync(request.UsuarioId);
        var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(request.MinisterioId);

        await _service.GaranteNaoExisteUsuarioMinisterioAsync(usuario.Id, ministerio.Id);
        
        var usuarioMinisterio = new UsuarioMinisterio(usuario, ministerio);

        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(usuarioMinisterio);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("usuario_ministerios", usuarioMinisterio.Id, "Usuário vinculado ao ministério.");
        await _uow.CommitTransacaoAsync();
        
        var result = _mapper.Map<CriarUsuarioMinisterioResult>(usuarioMinisterio);
        
        return result;
    }
}