namespace ApplicationServices.Queries.Dtos;

public sealed class OrderLineQueryDto
{
    public int ProductId { get; init; }
    public uint Quantity { get; init; }
    public ulong ProductPrice { get; init; }
    public ulong ExecutionPrice { get; init; }
}
