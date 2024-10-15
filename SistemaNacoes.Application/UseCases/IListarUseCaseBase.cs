using SistemaNacoes.Application.Dtos;
using SistemaNacoes.Shared.Paginacao;

namespace SistemaNacoes.Application.UseCases;

public interface IListarUseCaseBase<TResult, TParam>
    where TResult : Result
    where TParam : Param
{
    Task<PaginadoResult<TResult>> ExecutarAsync(TParam param);
}