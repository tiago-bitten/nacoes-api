using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Application.UseCases.Permissoes.RemoverPermissao.Dtos;

public class RemoverPermissaoRequest : Request
{
    [JsonPropertyName("PerfilAcessoId")]
    public int PerfilAcessoId { get; set; }
    
    [JsonPropertyName("PermissoesId")]
    public List<EPermissoes> PermissoesId { get; set; }
}