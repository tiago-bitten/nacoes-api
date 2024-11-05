namespace SistemaNacoes.Shared.Paginacao;

public class PaginadoResult<T> where T : class
{
    public List<T> Dados { get; set; } = new();
    public int Pagina { get; set; } 
    public int Tamanho { get; set; }
    public int Total { get; set; } 
    public bool TemProximo { get; set; } 
    public bool TemAnterior { get; set; }
}
