using AutoMapper;
using SistemaNacoes.Application.Dtos.Auth;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Auth;

public class Login
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IRegistroLoginService _registroLoginService;

    public Login(IUnitOfWork uow, IMapper mapper, ITokenService tokenService, IRegistroLoginService registroLoginService)
    {
        _uow = uow;
        _mapper = mapper;
        _tokenService = tokenService;
        _registroLoginService = registroLoginService;
    }

    public async Task<RespostaBase<GetAuthTokenDto>> ExecuteAsync(LoginDto dto)
    {
        var usuario = await _uow.Usuarios.BuscarAsync(x => x.Email.ToUpper() == dto.Email.ToUpper());
        
        if (usuario == null)
        {
            await _registroLoginService.LogFailedLoginAsync(null, EMotivoLoginAcessoNegado.UsuarioNaoEncontrado);
            await _uow.CommitAsync();
            throw new Exception(MensagemErroConstant.LoginInvalido);
        }

        var senhaInvalida = !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);

        if (senhaInvalida)
        {
            await _registroLoginService.LogFailedLoginAsync(usuario.Id, EMotivoLoginAcessoNegado.SenhaIncorreta);
            await _uow.CommitAsync();
            throw new Exception(MensagemErroConstant.LoginInvalido);
        }
    
        await _registroLoginService.LogSuccessLoginAsync(usuario.Id);
    
        var accessToken = _tokenService.GenerateAccessToken(usuario);
        var refreshToken = await _tokenService.GenerateRefreshTokenAsync(usuario.Email);

        await _uow.CommitAsync();
        
        var authTokens = (
            AccessToken: accessToken,
            RefreshToken: refreshToken.Token,
            ExpiresIn: refreshToken.DataExpiracao);

        var authTokensDto = _mapper.Map<GetAuthTokenDto>(authTokens);
    
        var respostaBase = new RespostaBase<GetAuthTokenDto>(
            RespostaBaseMensagem.LoginSucesso, authTokensDto);
    
        return respostaBase;
    }
}