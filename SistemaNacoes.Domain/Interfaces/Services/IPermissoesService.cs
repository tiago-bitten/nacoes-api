namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IPermissoesService
{
    Dictionary<long, string> GetAllPermissoes();
    Task VerificarPermissaoAsync(long idPermissao, string mensagemErro = "Usuário não possui permissão para executar");
}