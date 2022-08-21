using DomainModels.UserAggregate.Data;
using DomainModels.UserAggregate.Entities;
using Framework.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UserAggregate;

public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Insert(User user, CancellationToken ct = default)
    {
        if (user is null)
        {
            throw new EShopException(
                "User can NOT be passed as null.",
                ExceptionStatus.InvalidArgument
            );
        }

        var entry = await _dbContext.Users.AddAsync(user, ct);
        return entry.Entity;
    }

    public async Task<IEnumerable<User>> Get(CancellationToken ct = default)
    {
        return await _dbContext.Users.ToListAsync(ct);
    }

    public async Task<User> GetById(int id, CancellationToken ct = default)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id, ct);

        if (user is null)
        {
            throw new EShopException(
                "There is NO user with the given id",
                ExceptionStatus.NotFound
            );
        }

        return user;
    }

    public async Task<User> Delete(int id, CancellationToken ct = default)
    {
        var user = await GetById(id, ct);
        var entry = _dbContext.Users.Remove(user);
        return entry.Entity;
    }
}
