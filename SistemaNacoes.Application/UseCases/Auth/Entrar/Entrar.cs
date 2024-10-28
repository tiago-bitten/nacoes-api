using AutoMapper;
using SistemaNacoes.Application.UseCases.Auth.Entrar.Dtos;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.HistoricoLogin;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Entidades.Usuario;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Application.UseCases.Auth.Entrar;

public class Entrar : IEntrarUseCase
{
    #region Ctor
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IHistoricoLoginService _historicoLogin;
    private readonly IUsuarioService _usuarioService;
    
    public Entrar(ITokenService tokenService, IUsuarioService usuarioService, IUnitOfWork uow, IMapper mapper, IHistoricoLoginService historicoLogin)
    {
        _tokenService = tokenService;
        _usuarioService = usuarioService;
        _uow = uow;
        _mapper = mapper;
        _historicoLogin = historicoLogin;
    }
    #endregion
    
    public async Task<EntrarResult> ExecutarAsync(EntrarRequest request)
    {
        var usuario = await _usuarioService.RecuperarPorEmailAsync(request.Email);
        
        if (usuario == null)
        {
            await _uow.IniciarTransacaoAsync();
            await _historicoLogin.NegadoAsync(null, EMotivoLoginAcessoNegado.UsuarioNaoEncontrado);
            await _uow.CommitTransacaoAsync();
            throw new NacoesAppException(MensagemErroConstant.LoginInvalido);
        }

        var senhaInvalida = SenhaHelper.Verificar(request.Senha, usuario.SenhaHash);

        if (senhaInvalida)
        {
            await _uow.IniciarTransacaoAsync();
            await _historicoLogin.NegadoAsync(usuario.Id, EMotivoLoginAcessoNegado.SenhaIncorreta);
            await _uow.CommitTransacaoAsync();
            throw new NacoesAppException(MensagemErroConstant.LoginInvalido);
        }
    
        await _uow.IniciarTransacaoAsync();
        await _historicoLogin.SucessoAsync(usuario.Id);
    
        var accessToken = _tokenService.GenerateAccessToken(usuario);
        var refreshToken = await _tokenService.GenerateRefreshTokenAsync(usuario.Email);
        await _uow.CommitTransacaoAsync();
        
        var authTokens = (
            AccessToken: accessToken,
            RefreshToken: refreshToken.Token);

        var result = _mapper.Map<EntrarResult>(authTokens);

        return result;
    }
}