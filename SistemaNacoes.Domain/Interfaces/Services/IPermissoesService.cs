namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IPermissoesService
{
    Dictionary<long, string> GetAllPermissoes();
}