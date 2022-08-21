using DomainModels.OrderAggregate.Entities;
using DomainModels.ProductAggregate.Entities;

namespace DomainServices.Abstractions;

public interface IOrderService
{
    void ValidateMarketTime();
    void ValidateOrderPrice(ulong finalPrice);
    IEnumerable<OrderLine> CalculateOrderLinesExecutionPrices(IEnumerable<(Product product, uint quantity)> products);
    ulong CalculateOrderPrice(IEnumerable<OrderLine> orderLines);
}
