using AutoMapper;
using SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Entidades.PerfilAcesso;
using SistemaNacoes.Domain.Entidades.Usuario;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario;

public class CriarUsuario : ICriarUsuarioUseCase
{
    #region Ctor
    private readonly IUsuarioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IPerfilAcessoService _perfilAcessoService;

    public CriarUsuario(IUsuarioService service, IUnitOfWork uow, IMapper mapper, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService, IPerfilAcessoService perfilAcessoService)
    {
        _service = service;
        _uow = uow;
        _mapper = mapper;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
        _perfilAcessoService = perfilAcessoService;
    }
    #endregion

    public async Task<CriarUsuarioResult> ExecutarAsync(CriarUsuarioRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarUsuario,
            "Você não possui permissão para criar usuários.");

        await _service.GaranteNaoExisteUsuarioCriadoAsync(request.Email, request.Cpf);
        var perfilAcesso = await _perfilAcessoService.RecuperaGaranteExisteAsync(request.PerfilAcessoId);
        
        var usuario = _mapper.Map<Usuario>(request);

        usuario.SenhaHash = SenhaHelper.Provisionar(); // Data de hoje
        usuario.PerfilAcesso = perfilAcesso;

        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(usuario);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("usuarios", usuario.Id, "Usuário criado.");
        await _uow.CommitTransacaoAsync();

        var result = _mapper.Map<CriarUsuarioResult>(usuario);

        return result;
    }
}