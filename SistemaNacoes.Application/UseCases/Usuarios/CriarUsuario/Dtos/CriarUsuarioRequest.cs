using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario.Dtos;

public class CriarUsuarioRequest : Request
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("Email")]
    public string Email { get; set; }
    
    [JsonPropertyName("Celular")]
    public string? Celular { get; set; }
    
    [JsonPropertyName("Cpf")]
    public string? Cpf { get; set; }
    
    [JsonPropertyName("DataNascimento")]
    public DateTime? DataNascimento { get; set; }
    
    [JsonPropertyName("PerfilAcessoId")]
    public int PerfilAcessoId { get; set; }
}