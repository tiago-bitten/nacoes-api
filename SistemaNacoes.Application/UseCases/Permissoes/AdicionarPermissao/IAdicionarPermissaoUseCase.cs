using System.Text.Json.Serialization;
using SistemaNacoes.Application.UseCases.Permissoes.AdicionarPermissao.Dtos;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Application.UseCases.Permissoes.AdicionarPermissao;

public interface IAdicionarPermissaoUseCase : ICommandUseCaseBase<AdicionarPermissaoRequest>
{

}