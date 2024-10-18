namespace SistemaNacoes.Domain.Interfaces.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        Task IniciarTransacaoAsync();
        Task CommitTransacaoAsync();
    }
}