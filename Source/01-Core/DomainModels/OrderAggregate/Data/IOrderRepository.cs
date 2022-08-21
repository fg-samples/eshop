using DomainModels.OrderAggregate.Entities;

namespace DomainModels.OrderAggregate.Data;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> Get(CancellationToken ct = default);
    Task<Order> GetById(int id, CancellationToken ct = default);
    Task<Order> Insert(Order Order, CancellationToken ct = default);
    Task<Order> Delete(int id, CancellationToken ct = default);
}
