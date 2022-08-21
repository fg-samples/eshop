using DomainModels.OrderAggregate.Data;
using DomainModels.OrderAggregate.Entities;
using Framework.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.OrderAggregate;

public sealed class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> Insert(Order order, CancellationToken ct = default)
    {
        if (order is null)
        {
            throw new EShopException(
                "Order can NOT be passed as null.",
                ExceptionStatus.InvalidArgument
            );
        }

        var entry = await _dbContext.Orders.AddAsync(order, ct);
        return entry.Entity;
    }

    public async Task<IEnumerable<Order>> Get(CancellationToken ct = default)
    {
        return await _dbContext.Orders.ToListAsync(ct);
    }

    public async Task<Order> GetById(int id, CancellationToken ct = default)
    {
        var order = await _dbContext.Orders.SingleOrDefaultAsync(u => u.Id == id, ct);

        if (order is null)
        {
            throw new EShopException(
                "There is NO order with the given id",
                ExceptionStatus.NotFound
            );
        }

        return order;
    }

    public async Task<Order> Delete(int id, CancellationToken ct = default)
    {
        var order = await GetById(id, ct);
        var entry = _dbContext.Orders.Remove(order);
        return entry.Entity;
    }
}
