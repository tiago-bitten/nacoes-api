namespace SistemaNacoes.Domain.Entidades.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        Task IniciarTransacaoAsync();
        Task CommitTransacaoAsync();
    }
}