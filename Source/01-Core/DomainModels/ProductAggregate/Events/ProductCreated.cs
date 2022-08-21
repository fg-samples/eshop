using Framework.Events;

namespace DomainModels.ProductAggregate.Events;

public sealed class ProductCreated : IEvent
{
    public Guid EventId { get; private set; }
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public ulong Price { get; init; }
    public bool IsBreakable { get; init; }

    public void SetEventId(Guid eventId)
    {
        EventId = eventId;
    }
}
