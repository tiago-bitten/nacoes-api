using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Data;

public class UnitOfWork : IUnitOfWork
{
    #region Ctor
    private readonly NacoesDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(NacoesDbContext context)
    {
        _context = context;
    }
    #endregion

    #region IniciarTransacaoAsync
    public async Task IniciarTransacaoAsync()
    {
        if (_transaction != null)
        {
            throw new InvalidOperationException("Já existe uma transação aberta.");
        }

        _transaction = await _context.Database.BeginTransactionAsync();
    }
    #endregion

    #region CommitTransacaoAsync
    public async Task CommitTransacaoAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Nenhuma transação foi iniciada para commit.");
        }

        try
        {
            await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackTransacaoAsync();
            throw;
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
    #endregion

    #region RollbackTransacaoAsync
    public async Task RollbackTransacaoAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Nenhuma transação foi iniciada para rollback.");
        }

        try
        {
            await _transaction.RollbackAsync();
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
    #endregion

    #region Dispose
    public void Dispose()
    {
        _context.Dispose();
        _transaction?.Dispose();
    }
    #endregion
}