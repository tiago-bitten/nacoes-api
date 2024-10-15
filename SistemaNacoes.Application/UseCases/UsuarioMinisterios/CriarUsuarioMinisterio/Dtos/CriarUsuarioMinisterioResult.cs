using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.UsuarioMinisterios.CriarUsuarioMinisterio.Dtos;

public class CriarUsuarioMinisterioResult : Result
{
    [JsonPropertyName("UsuarioMinisterioId")]
    public int UsuarioMinisterioId { get; set; }
}