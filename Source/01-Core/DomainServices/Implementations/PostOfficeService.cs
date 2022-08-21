using DomainModels.OrderAggregate.Entities;
using DomainModels.ProductAggregate.Entities;
using DomainServices.Abstractions;

namespace DomainServices.Implementations;

public sealed class PostOfficeService : IPostOfficeService
{
    public PostType DeterminePostType(IEnumerable<Product> products, CancellationToken ct = default)
    {
        return products.Any(p => p.IsBreakable) ? PostType.Fast : PostType.Normal;
    }
}
