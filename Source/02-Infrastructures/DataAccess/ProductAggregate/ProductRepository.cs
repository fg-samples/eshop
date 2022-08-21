using DomainModels.ProductAggregate.Data;
using DomainModels.ProductAggregate.Entities;
using Framework.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ProductAggregate;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> Insert(Product product, CancellationToken ct = default)
    {
        if (product is null)
        {
            throw new EShopException(
                "Product can NOT be passed as null.",
                ExceptionStatus.InvalidArgument
            );
        }

        var entry = await _dbContext.Products.AddAsync(product, ct);
        return entry.Entity;
    }

    public async Task<IEnumerable<Product>> Get(CancellationToken ct = default)
    {
        return await _dbContext.Products.ToListAsync(ct);
    }

    public async Task<IEnumerable<Product>> GetRange(IEnumerable<int> ids, CancellationToken ct = default)
    {
        return await _dbContext.Products.Where(p => ids.Contains(p.Id)).ToListAsync(ct);
    }

    public async Task<Product> GetById(int id, CancellationToken ct = default)
    {
        var product = await _dbContext.Products.SingleOrDefaultAsync(u => u.Id == id, ct);

        if (product is null)
        {
            throw new EShopException(
                "There is NO product with the given id",
                ExceptionStatus.NotFound
            );
        }

        return product;
    }

    public async Task<Product> Delete(int id, CancellationToken ct = default)
    {
        var product = await GetById(id, ct);
        var entry = _dbContext.Products.Remove(product);
        return entry.Entity;
    }
}
