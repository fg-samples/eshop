using ApplicationServices.Queries.Dtos;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetProductQuery : IRequest<ProductDto>
{
    public int Id { get; init; }
}
