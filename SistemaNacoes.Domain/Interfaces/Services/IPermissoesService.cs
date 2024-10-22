using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IPermissoesService
{
    List<EPermissoes> RecuperarTodos();
    Task VerificaGarantePermissaoAsync(EPermissoes permissao, string mensagemErro = "Usuário não possui permissão para executar");
}