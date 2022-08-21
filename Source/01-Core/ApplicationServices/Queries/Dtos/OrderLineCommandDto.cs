namespace ApplicationServices.Queries.Dtos;

public sealed class OrderLineCommandDto
{
    public int ProductId { get; init; }
    public uint Quantity { get; init; }
}
