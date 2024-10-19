using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using AutoMapper;
using SistemaNacoes.Application.Dtos.Auth;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Auth;

public class RefreshToken_old
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;
    private readonly IServiceBase<Usuario> _usuarioService;
    private readonly IMapper _mapper;
    
    public RefreshToken_old(ITokenService tokenService, IServiceBase<Usuario> usuarioService, IUnitOfWork uow, IMapper mapper)
    {
        _tokenService = tokenService;
        _usuarioService = usuarioService;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<GetAuthTokenDto>> ExecuteAsync(RefreshAuthTokenDto dto)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(dto.AccessToken);

        var usuarioId = int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        var usuario = await _usuarioService.RecuperaGaranteExisteAsync(usuarioId);
        
        var refreshToken = await _uow.RefreshTokens.GetByTokenAsync(dto.RefreshToken);
        
        if (refreshToken is null || refreshToken.Revogado || refreshToken.DataExpiracao < DateTime.UtcNow || refreshToken.Principal != usuario.Email)
            throw new Exception(MensagemErroConstant.RefreshTokenNaoEncontrado);
        
        await _uow.IniciarTransacaoAsync();
        var newRefreshToken = await _tokenService.GenerateRefreshTokenAsync(usuario.Email);
        var newAccessToken = _tokenService.GenerateAccessToken(usuario);
        await _uow.CommitTransacaoAsync();

        var authToken = (
            AccessToken: newAccessToken,
            RefreshToken: newRefreshToken.Token,
            ExpiresIn: newRefreshToken.DataExpiracao);
        
        var getAuthTokenDto = _mapper.Map<GetAuthTokenDto>(authToken);
        
        var respostaBase = new RespostaBase<GetAuthTokenDto>(
            RespostaBaseMensagem.GetAuthToken, getAuthTokenDto);
        
        return respostaBase;
    }
}