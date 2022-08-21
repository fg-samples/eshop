using DomainModels.OrderAggregate.Entities;
using DomainModels.ProductAggregate.Entities;
using DomainServices.Abstractions;
using Framework.Exceptions;

namespace DomainServices.Implementations;

public sealed class OrderService : IOrderService
{
    const ulong MIN_ORDER_PRICE = 50_000;

    public void ValidateOrderPrice(ulong orderPrice)
    {
        if (orderPrice < MIN_ORDER_PRICE)
        {
            throw new EShopException($"Final price can not be less than {MIN_ORDER_PRICE}, Yours is {orderPrice}",
                ExceptionStatus.InvalidArgument);
        }
    }

    public ulong CalculateOrderPrice(IEnumerable<OrderLine> orderLines)
    {
        return (ulong)orderLines.Sum(o => (long)o.ExecutionPrice * o.Quantity);
    }

    public IEnumerable<OrderLine> CalculateOrderLinesExecutionPrices(
        IEnumerable<(Product product, uint quantity)> products)
    {
        var calculatedOrderLines = new List<OrderLine>(products.Count());

        foreach (var (product, quantity) in products)
        {
            var executionPrice = (ulong)(product.Price + 0.1 * product.Price);

            calculatedOrderLines.Add(OrderLine.Create(product.Id, quantity, product.Price, executionPrice));
        }

        return calculatedOrderLines;
    }

    public void ValidateMarketTime()
    {
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 19)
        {
            return;
        }

        throw new EShopException("Market is not open. Availability time is between 8 AM to 7 PM.",
            ExceptionStatus.PermissionDenied);
    }
}
