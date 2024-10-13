using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IPermissoesService
{
    Dictionary<long, string> GetAllPermissoes();
    Task VerificaGarantePermissaoAsync(EPermissoes permissao, string mensagemErro = "Usuário não possui permissão para executar");
}