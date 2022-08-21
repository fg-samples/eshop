using DomainModels.OrderAggregate.Entities;
using Framework.Events;

namespace DomainModels.OrderAggregate.Events;

public sealed class OrderCreated : IEvent
{
    public Guid EventId { get; private set; }
    public int Id { get; init; }
    public int UserId { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTime OrderDate { get; init; }
    public PostType PostType { get; init; }
    public IEnumerable<OrderLine> OrderLines { get; init; } = new HashSet<OrderLine>();

    public void SetEventId(Guid eventId)
    {
        EventId = eventId;
    }
}
