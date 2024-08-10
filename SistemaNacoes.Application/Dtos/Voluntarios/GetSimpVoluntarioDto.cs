using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Voluntarios;

public class GetSimpVoluntarioDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
}