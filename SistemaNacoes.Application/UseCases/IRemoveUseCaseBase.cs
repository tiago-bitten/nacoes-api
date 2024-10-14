using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases;

public interface IRemoveUseCaseBase
{
    Task ExecutarAsync(int id);
}