namespace ApplicationServices.Queries.Dtos;

public sealed class OrderQueryDto
{
    public int Id { get; init; }
    public int UserId { get; set; }
    public string Description { get; init; } = string.Empty;
    public IEnumerable<OrderLineQueryDto> OrderLines { get; init; } = new HashSet<OrderLineQueryDto>();
}
