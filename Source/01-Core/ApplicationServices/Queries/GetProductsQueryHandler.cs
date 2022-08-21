using ApplicationServices.Queries.Dtos;
using AutoMapper;
using DomainModels.ProductAggregate.Data;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery rq, CancellationToken ct)
    {
        var dbProducts = await _productRepository.Get(ct);

        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(dbProducts);

        return productDtos;
    }
}
