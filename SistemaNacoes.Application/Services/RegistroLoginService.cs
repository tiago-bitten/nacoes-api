using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class RegistroLoginService : IRegistroLoginService
{
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;

    public RegistroLoginService(IUnitOfWork uow, IAmbienteUsuarioService ambienteUsuarioService)
    {
        _uow = uow;
        _ambienteUsuarioService = ambienteUsuarioService;
    }

    public async Task LoginAttemptAsync(RegistroLogin registroLogin)
    {
        await _uow.RegistroLogins.AddAsync(registroLogin);
        await _uow.CommitAsync();
    }

    public async Task LogSuccessLoginAsync(int usuarioId)
    {
        var ip = _ambienteUsuarioService.GetUsuarioIp();
        var userAgent = _ambienteUsuarioService.GetUsuarioUserAgent();
        var registroLogin = new RegistroLogin(usuarioId, ip, userAgent);
        await LoginAttemptAsync(registroLogin);
    }

    public async Task LogFailedLoginAsync(int? usuarioId, EMotivoLoginAcessoNegado motivo)
    {
        var ip = _ambienteUsuarioService.GetUsuarioIp();
        var userAgent = _ambienteUsuarioService.GetUsuarioUserAgent();
        
        var registroLogin = new RegistroLogin();
        
        // TODO: revisar imp de 'UsuarioId', talvez esteja redundante, pois já está nullable
        registroLogin.UsuarioId = usuarioId ?? null;
        registroLogin.Ip = ip;
        registroLogin.UserAgent = userAgent;
        registroLogin.Motivo = motivo;
        registroLogin.Sucesso = false;
        
        await LoginAttemptAsync(registroLogin);
    }
}