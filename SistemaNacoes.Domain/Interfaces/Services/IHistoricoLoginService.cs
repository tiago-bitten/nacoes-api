using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IHistoricoLoginService
{
    Task RealizarTentativaAsync(HistoricoLogin registroLogin);    
    Task SucessoAsync(int usuarioId);
    Task NegadoAsync(int? usuarioId, EMotivoLoginAcessoNegado motivo);
}