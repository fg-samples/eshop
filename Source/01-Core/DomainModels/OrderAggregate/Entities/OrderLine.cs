namespace DomainModels.OrderAggregate.Entities;

public sealed class OrderLine
{
    private OrderLine()
    {}

    public static OrderLine Create(int productId, uint quantity, ulong productPrice, ulong executionPrice)
    {
        return new OrderLine
        {
            ProductId = productId,
            Quantity = quantity,
            ProductPrice = productPrice,
            ExecutionPrice = executionPrice,
        };
    }

    public int ProductId { get; private set; }
    public uint Quantity { get; private set; }
    public ulong ProductPrice { get; private set; }
    public ulong ExecutionPrice { get; private set; }
}