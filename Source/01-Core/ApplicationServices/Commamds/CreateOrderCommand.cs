using ApplicationServices.Queries.Dtos;
using MediatR;

namespace ApplicationServices.Commands;

public sealed class CreateOrderCommand : IRequest<int>
{
    public string Description { get; init; } = string.Empty;
    public int UserId { get; init; }
    public IEnumerable<OrderLineCommandDto> OrderLines { get; set; } = new HashSet<OrderLineCommandDto>();
}
