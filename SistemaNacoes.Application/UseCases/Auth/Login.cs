using AutoMapper;
using SistemaNacoes.Application.Dtos.Auth;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Auth;

public class Login
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    
    public Login(IUnitOfWork uow, IMapper mapper, ITokenService tokenService)
    {
        _uow = uow;
        _mapper = mapper;
        _tokenService = tokenService;
    }
    
    public async Task<RespostaBase<GetAuthTokenDto>> ExecuteAsync(LoginDto dto)
    {
        var usuario = await _uow.Usuarios.FindAsync(x => x.Email.ToUpper() == dto.Email.ToUpper());

        var senhaInvalida = !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);

        if (usuario == null || senhaInvalida)
            throw new Exception(MensagemErroConstant.LoginInvalido);
        
        var accessToken = _tokenService.GenerateAccessToken(usuario);
        var refreshToken = await _tokenService.GenerateRefreshTokenAsync(usuario.Email);

        var authTokens = (
            AccessToken: accessToken,
            RefreshToken: refreshToken.Token,
            ExpiresIn: refreshToken.DataExpiracao);

        var authTokensDto = _mapper.Map<GetAuthTokenDto>(authTokens);
        
        var respostaBase = new RespostaBase<GetAuthTokenDto>(
            MensagemRepostaConstant.LoginSucesso, authTokensDto);
        
        return respostaBase;
    }
}