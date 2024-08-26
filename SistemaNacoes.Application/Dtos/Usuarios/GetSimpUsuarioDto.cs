using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Usuarios;

public class GetSimpUsuarioDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("Email")]
    public string Email { get; set; }
}