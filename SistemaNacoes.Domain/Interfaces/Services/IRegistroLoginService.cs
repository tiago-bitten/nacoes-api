using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IRegistroLoginService
{
    Task LoginAttemptAsync(RegistroLogin registroLogin);    
    Task LogSuccessLoginAsync(int usuarioId, string ip, string userAgent);
    Task LogFailedLoginAsync(int? usuarioId, string ip, string userAgent, EMotivoLoginAcessoNegado motivo);
}