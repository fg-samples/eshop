using DomainModels.ProductAggregate.Data;
using DomainModels.ProductAggregate.Entities;
using Framework.Data;
using MediatR;

namespace ApplicationServices.Commands;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateProductCommand rq, CancellationToken ct)
    {
        var product = Product.Create(rq.Name, rq.Price, rq.IsBreakable);
        var dbProduct = await _productRepository.Insert(product, ct);
        await _unitOfWork.SaveChanges(ct);

        return dbProduct.Id;
    }
}
