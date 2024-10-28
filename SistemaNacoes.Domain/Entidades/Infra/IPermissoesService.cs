using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades.Infra;

public interface IPermissoesService
{
    List<EPermissoes> RecuperarTodos();
    Task VerificaGarantePermissaoAsync(EPermissoes permissao, string mensagemErro = "Usuário não possui permissão para executar");
}