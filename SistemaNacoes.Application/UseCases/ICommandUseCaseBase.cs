using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases;

public interface ICommandUseCaseBase<TResult, TRequest> 
    where TResult : Result
    where TRequest : Request
{
    Task<TResult> ExecutarAsync(TRequest request);
}

public interface ICommandUseCaseBase
{
    Task ExecutarAsync(int id);
}