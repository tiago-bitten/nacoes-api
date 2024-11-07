using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Adm.LogarComUsuario.Dtos;

public class LogarComUsuarioRequest : Request
{
    [JsonPropertyName("UsuarioId")]
    public int UsuarioId { get; set; }
}