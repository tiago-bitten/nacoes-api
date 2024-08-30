using AutoMapper;
using SistemaNacoes.Application.Dtos.Auth;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Auth;

public class Login
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IRegistroLoginService _registroLoginService;
    
    public Login(IUnitOfWork uow, IMapper mapper, ITokenService tokenService, IAmbienteUsuarioService ambienteUsuarioService, IRegistroLoginService registroLoginService)
    {
        _uow = uow;
        _mapper = mapper;
        _tokenService = tokenService;
        _ambienteUsuarioService = ambienteUsuarioService;
        _registroLoginService = registroLoginService;
    }
    
    public async Task<RespostaBase<GetAuthTokenDto>> ExecuteAsync(LoginDto dto)
    {
        var usuario = await _uow.Usuarios.FindAsync(x => x.Email.ToUpper() == dto.Email.ToUpper());
        var ip = _ambienteUsuarioService.GetUsuarioIp();
        var userAgent = _ambienteUsuarioService.GetUsuarioUserAgent();
        
        var senhaInvalida = !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);

        if (usuario == null || senhaInvalida)
        {
            var motivo = senhaInvalida ? EMotivoLoginAcessoNegado.SenhaIncorreta : EMotivoLoginAcessoNegado.UsuarioNaoEncontrado;
            await _registroLoginService.LogFailedLoginAsync(usuario?.Id ?? null, ip, userAgent, motivo);
            throw new Exception(MensagemErroConstant.LoginInvalido);
        }
        
        await _registroLoginService.LogSuccessLoginAsync(usuario.Id, ip, userAgent);
        
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