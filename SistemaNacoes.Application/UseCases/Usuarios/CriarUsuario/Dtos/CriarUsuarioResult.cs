using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario.Dtos;

public class CriarUsuarioResult : Result
{
    [JsonPropertyName("UsuarioId")]
    public int UsuarioId { get; set; }
}