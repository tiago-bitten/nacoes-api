using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Ministerios.CriarMinisterio.Dtos;

public class CriarMinisterioRequest : Request
{
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public string Cor { get; set; }
}