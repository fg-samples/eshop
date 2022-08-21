using ApplicationServices.Queries.Dtos;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetOrdersQuery : IRequest<IEnumerable<OrderQueryDto>>
{ }
