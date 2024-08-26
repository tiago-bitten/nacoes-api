using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Permissoes;

public class GetPermissaoDto
{
    [JsonPropertyName("Identificador")]
    public long Identificador { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("NomeFormatado")]
    public string NomeFormatado { get; set; }
    
    [JsonPropertyName("PossuiPermissao")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PossuiPermissao { get; set; } 
}