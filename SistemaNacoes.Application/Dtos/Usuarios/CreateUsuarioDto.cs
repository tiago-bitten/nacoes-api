using System.Text.Json.Serialization;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Application.Dtos.Usuarios;

public class CreateUsuarioDto
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("Email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("Celular")]
    public string? Celular { get; set; }
    
    [JsonPropertyName("Cpf")]
    public string? Cpf { get; set; }
    
    [JsonPropertyName("DataNascimento")]
    public DateTime? DataNascimento { get; set; }
    
    // [JsonPropertyName("Permissoes")]
    // public EPermissoes Permissoes { get; set; }
}