using ApplicationServices.Queries.Dtos;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetOrderQuery : IRequest<OrderQueryDto>
{
    public int Id { get; init; }
}
