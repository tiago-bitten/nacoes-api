using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.UsuarioMinisterios;

public class VinculateUsuarioMinisterioDto
{
    [JsonPropertyName("UsuarioId")]
    public int UsuarioId { get; set; }
    
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
}