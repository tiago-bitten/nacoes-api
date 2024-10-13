using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases;

public interface ICommandUseCaseBase<TResult, TRequest> 
    where TResult : Response
    where TRequest : Request
{
    Task<TResult> ExecutarAsync(TRequest request);
}