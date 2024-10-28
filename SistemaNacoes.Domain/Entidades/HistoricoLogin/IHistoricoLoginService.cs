using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades.HistoricoLogin;

public interface IHistoricoLoginService
{
    Task RealizarTentativaAsync(HistoricoLogin registroLogin);    
    Task SucessoAsync(int usuarioId);
    Task NegadoAsync(int? usuarioId, EMotivoLoginAcessoNegado motivo);
}