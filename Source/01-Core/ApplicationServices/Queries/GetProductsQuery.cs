using ApplicationServices.Queries.Dtos;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
{ }
