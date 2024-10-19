using System.Security.Claims;
using AutoMapper;
using SistemaNacoes.Application.UseCases.Auth.RefreshToken.Dtos;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Auth.RefreshToken;

public class RefreshToken : IRefreshTokenUseCase
{
    #region Ctor
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IUsuarioService _usuarioService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public RefreshToken(ITokenService tokenService, IMapper mapper, IUsuarioService usuarioService, IUnitOfWork uow, IRefreshTokenRepository refreshTokenRepository)
    {
        _tokenService = tokenService;
        _mapper = mapper;
        _usuarioService = usuarioService;
        _uow = uow;
        _refreshTokenRepository = refreshTokenRepository;
    }
    #endregion
    
    public async Task<RefreshTokenResult> ExecutarAsync(RefreshTokenRequest request)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

        var usuarioId = int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        var usuario = await _usuarioService.RecuperaGaranteExisteAsync(usuarioId);
        
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);
        
        if (refreshToken is null || refreshToken.Revogado || refreshToken.DataExpiracao < DateTime.UtcNow || refreshToken.Principal != usuario.Email)
            throw new Exception(MensagemErroConstant.RefreshTokenNaoEncontrado);
        
        await _uow.IniciarTransacaoAsync();
        var newRefreshToken = await _tokenService.GenerateRefreshTokenAsync(usuario.Email);
        var newAccessToken = _tokenService.GenerateAccessToken(usuario);
        await _uow.CommitTransacaoAsync();

        var authToken = (
            AccessToken: newAccessToken,
            RefreshToken: newRefreshToken.Token);
        
        var result = _mapper.Map<RefreshTokenResult>(authToken);

        return result;
    }
}