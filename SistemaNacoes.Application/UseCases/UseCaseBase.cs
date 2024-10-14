using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases;

public class UseCaseBase
{
    private IUnitOfWork _uow;

    protected UseCaseBase(IUnitOfWork uow)
    {
        _uow = uow;
    }

    protected async Task IniciarTransacaoAsync()
    {
        await _uow.IniciarTransacaoAsync();
    }

    protected async Task CommitTransacaoAsync()
    {
        await _uow.CommitTransacaoAsync();
    }
}