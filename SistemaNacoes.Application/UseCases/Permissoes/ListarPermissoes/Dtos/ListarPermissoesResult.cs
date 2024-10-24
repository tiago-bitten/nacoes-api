using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Shared.Extensions;

namespace SistemaNacoes.Application.UseCases.Permissoes.ListarPermissoes.Dtos;

public class ListarPermissoesResult : Result
{
    [JsonPropertyName("Identificador")]
    public long Identificador { get; set; }
    
    [JsonPropertyName("Enum")]
    public string Enum { get; set; }
    
    [JsonPropertyName("Descricao")]
    public string Descricao { get; set; }

    public static ListarPermissoesResult Adicionar(EPermissoes permissao)
    {
        return new ListarPermissoesResult
        {
            Identificador = (long)permissao,
            Enum = permissao.ToString(),
            Descricao = permissao.RecuperarDescricao()
        };
    }
}