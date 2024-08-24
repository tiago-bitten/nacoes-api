using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Auth;

public class Login
{
    private readonly IUnitOfWork _uow;

    public Login(IUnitOfWork uow)
    {
        _uow = uow;
    }
}