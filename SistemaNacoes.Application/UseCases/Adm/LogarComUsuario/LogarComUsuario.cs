using SistemaNacoes.Application.UseCases.Adm.LogarComUsuario.Dtos;

namespace SistemaNacoes.Application.UseCases.Adm.LogarComUsuario;

public class LogarComUsuario : ILogarComUsuarioUseCase
{
    #region Ctor
    private readonly ILogarComUsuarioUseCase _logar;

    public LogarComUsuario(ILogarComUsuarioUseCase logar)
    {
        _logar = logar;
    }

    #endregion
    
    public Task<LogarComUsuarioResult> ExecutarAsync(LogarComUsuarioRequest request)
    {
        throw new NotImplementedException();
    }
} 