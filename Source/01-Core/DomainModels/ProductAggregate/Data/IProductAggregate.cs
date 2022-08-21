using DomainModels.ProductAggregate.Entities;

namespace DomainModels.ProductAggregate.Data;

public interface IProductRepository
{
    Task<IEnumerable<Product>> Get(CancellationToken ct = default);
    Task<IEnumerable<Product>> GetRange(IEnumerable<int> ids, CancellationToken ct = default);
    Task<Product> GetById(int id, CancellationToken ct = default);
    Task<Product> Insert(Product product, CancellationToken ct = default);
    Task<Product> Delete(int id, CancellationToken ct = default);
}
