using DomainModels.UserAggregate.Entities;

namespace DomainModels.UserAggregate.Data;

public interface IUserRepository
{
    Task<IEnumerable<User>> Get(CancellationToken ct = default);
    Task<User> GetById(int id, CancellationToken ct = default);
    Task<User> Insert(User user, CancellationToken ct = default);
    Task<User> Delete(int id, CancellationToken ct = default);
}
