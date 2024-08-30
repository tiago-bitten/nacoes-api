using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class RegistroLoginService : IRegistroLoginService
{
    private readonly IUnitOfWork _uow;

    public RegistroLoginService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task LoginAttemptAsync(RegistroLogin registroLogin)
    {
        await _uow.RegistroLogins.AddAsync(registroLogin);
    }

    public async Task LogSuccessLoginAsync(int usuarioId, string ip, string userAgent)
    {
        var registroLogin = new RegistroLogin(usuarioId, ip, userAgent);
        await LoginAttemptAsync(registroLogin);
    }

    public async Task LogFailedLoginAsync(int? usuarioId, string ip, string userAgent, EMotivoLoginAcessoNegado motivo)
    {
        var registroLogin = new RegistroLogin();
        
        registroLogin.UsuarioId = usuarioId ?? null;
        registroLogin.Ip = ip;
        registroLogin.UserAgent = userAgent;
        registroLogin.Motivo = motivo;
        registroLogin.Sucesso = false;
        
        await LoginAttemptAsync(registroLogin);
    }
}