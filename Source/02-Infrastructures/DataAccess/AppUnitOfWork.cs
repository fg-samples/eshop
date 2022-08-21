using Framework.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess;

public sealed class AppUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public AppUnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,
        CancellationToken ct = default)
    {
        await _dbContext.Database.BeginTransactionAsync(isolationLevel, ct);
    }

    public async Task SaveChanges(CancellationToken ct = default)
    {
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task CommitTransaction(CancellationToken ct = default)
    {
        await _dbContext.Database.CommitTransactionAsync(ct);
    }

    public async Task RollbackTransaction(CancellationToken ct = default)
    {
        await _dbContext.Database.RollbackTransactionAsync(ct);
    }
}