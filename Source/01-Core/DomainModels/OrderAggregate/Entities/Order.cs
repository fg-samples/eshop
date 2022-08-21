using DomainModels.OrderAggregate.Events;
using DomainModels.OrderAggregate.ValueObjects;
using Framework.Entities;
using Framework.Events;
using Framework.Exceptions;

namespace DomainModels.OrderAggregate.Entities;

public sealed class Order : AggregateRoot<int>
{
    private Order()
    { }

    public static Order Create(int userId, string description, PostType postType, IEnumerable<OrderLine> orderLines)
    {
        var order = new Order();

        order.Emit(new OrderCreated
        {
            UserId = userId,
            Description = description,
            OrderDate = DateTime.UtcNow,
            OrderLines = orderLines,
            PostType = postType,
        });

        return order;
    }

    public int UserId { get; private set; }
    public OrderDescription Description { get; private set; } = OrderDescription.Default;
    public DateTime OrderDate { get; private set; }
    public PostType PostType { get; private set; }
    public IEnumerable<OrderLine> OrderLines { get; private set; } = new HashSet<OrderLine>();

    protected override void SetStateByEvent(IEvent @event)
    {
        switch (@event)
        {
            case OrderCreated e:
                Id = e.Id;
                UserId = e.UserId;
                Description = e.Description;
                OrderDate = e.OrderDate;
                PostType = e.PostType;
                OrderLines = e.OrderLines;
                break;
            default:
                throw new EShopException("There is no such an event for product.");
        }
    }

    protected override void ValidateInvariants()
    {
        if (!OrderLines.Any())
        {
            throw new EShopException("Order lines count must be greater than 0.");
        }
    }
}
