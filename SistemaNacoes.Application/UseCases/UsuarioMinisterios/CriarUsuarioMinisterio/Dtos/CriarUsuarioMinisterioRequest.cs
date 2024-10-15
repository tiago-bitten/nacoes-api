using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.UsuarioMinisterios.CriarUsuarioMinisterio.Dtos;

public class CriarUsuarioMinisterioRequest : Request
{
    [JsonPropertyName("UsuarioId")]
    public int UsuarioId { get; set; }
    
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
}