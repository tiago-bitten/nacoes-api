namespace SistemaNacoes.Domain.Entidades.HistoricoEntidade;

public interface IHistoricoEntidadeService
{
    Task RegistrarAsync(string tabela, int itemId, string descricao);
    Task RegistrarVariosAsync(string tabela, IEnumerable<int> itemIds, string descricao);
}