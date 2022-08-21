using DomainModels.OrderAggregate.Entities;
using DomainModels.ProductAggregate.Entities;

namespace DomainServices.Abstractions;

public interface IPostOfficeService
{
    PostType DeterminePostType(IEnumerable<Product> products, CancellationToken ct = default);
}
