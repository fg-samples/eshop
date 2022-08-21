namespace ApplicationServices.Queries.Dtos;

public sealed class OrderCommandDto
{
    public int Id { get; init; }
    public int UserId { get; set; }
    public string Description { get; init; } = string.Empty;
    public IEnumerable<OrderLineCommandDto> OrderLines { get; init; } = new HashSet<OrderLineCommandDto>();
}
