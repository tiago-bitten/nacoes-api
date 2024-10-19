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

    public async Task LoginAttemptAsync(HistoricoLogin registroLogin)
    {
        await _uow.RegistroLogins.AddAsync(registroLogin);
    }

    public async Task LogSuccessLoginAsync(int usuarioId)
    {
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        var registroLogin = new HistoricoLogin
        {
            Sucesso = true,
            UsuarioId = usuarioId,
            Ip = ip,
            UserAgent = userAgent

        };
        await LoginAttemptAsync(registroLogin);
    }

    public async Task LogFailedLoginAsync(int? usuarioId, EMotivoLoginAcessoNegado motivo)
    {
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        
        var registroLogin = new HistoricoLogin();
        
        registroLogin.UsuarioId = usuarioId;
        registroLogin.Ip = ip;
        registroLogin.UserAgent = userAgent;
        registroLogin.Motivo = motivo;
        registroLogin.Sucesso = false;
        
        await LoginAttemptAsync(registroLogin);
    }
}