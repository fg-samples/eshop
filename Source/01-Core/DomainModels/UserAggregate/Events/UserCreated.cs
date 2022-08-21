using Framework.Events;

namespace DomainModels.UserAggregate.Events;

public sealed class UserCreated : IEvent
{
    public Guid EventId { get; private set; }
    public int Id { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;

    public void SetEventId(Guid eventId)
    {
        EventId = eventId;
    }
}
