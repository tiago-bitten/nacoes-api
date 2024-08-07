namespace SistemaNacoes.Application.Responses;

public class QueryParametro
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
    public string? OrderBy { get; set; }
}