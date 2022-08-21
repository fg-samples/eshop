using System.Data;

namespace Framework.Data;

public interface IUnitOfWork
{
    Task BeginTransaction(IsolationLevel isolationLevel, CancellationToken ct = default);
    Task SaveChanges(CancellationToken ct = default);
    Task CommitTransaction(CancellationToken ct = default);
    Task RollbackTransaction(CancellationToken ct = default);
}
