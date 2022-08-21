using ApplicationServices.Queries.Dtos;
using AutoMapper;
using DomainModels.ProductAggregate.Data;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductQuery rq, CancellationToken ct)
    {
        var dbProduct = await _productRepository.GetById(rq.Id, ct);

        var productDto = _mapper.Map<ProductDto>(dbProduct);

        return productDto;
    }
}
