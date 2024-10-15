using Microsoft.EntityFrameworkCore;

namespace SistemaNacoes.Shared.Paginacao;

public static class PaginacaoExtensions
{
    public static async Task<PaginadoResult<T>> PaginarAsync<T>(this IQueryable<T> query, int pagina, int tamanho) where T : class
    {
        if (pagina < 0)
            throw new ArgumentException("A página não pode ser negativa.", nameof(pagina));
            
        if (tamanho <= 0)
            throw new ArgumentException("O tamanho da página deve ser maior que zero.", nameof(tamanho));
            
        var total = await query.CountAsync();

        var dados = await query.Skip(pagina * tamanho).Take(tamanho).ToListAsync();

        return new PaginadoResult<T>
        {
            Dados = dados,
            Pagina = pagina,
            Tamanho = tamanho,
            Total = total,
            TemProximo = (pagina + 1) * tamanho < total,
            TemAnterior = pagina > 0
        };
    }
}