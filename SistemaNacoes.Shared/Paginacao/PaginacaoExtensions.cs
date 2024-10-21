using Microsoft.EntityFrameworkCore;

namespace SistemaNacoes.Shared.Paginacao;

public static class PaginacaoExtensions
{
    public static async Task<PaginadoResult<T>> PaginarAsync<T>(this IQueryable<T> query, int pagina, int tamanho) where T : class
    {
        if (pagina < 0)
            throw new ArgumentException("A página não pode ser negativa.", nameof(pagina));
            
        switch (tamanho)
        {
            case <= 0:
                throw new ArgumentException("O tamanho da página deve ser maior que zero.", nameof(tamanho));
            case >= 150:
                throw new ArgumentException("O tamanho da página deve ser menor que 150.", nameof(tamanho));
        }

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

    public static PaginadoResult<T> ConverterDadosPaginacao<T, R>(this List<T> list, PaginadoResult<R> paginado) 
        where T : class
        where R : class
    {
        return new PaginadoResult<T>
        {
            Dados = list,
            Pagina = paginado.Pagina,
            Tamanho = paginado.Tamanho,
            Total = paginado.Total,
            TemProximo = paginado.TemProximo,
            TemAnterior = paginado.TemAnterior
        };
    }
}