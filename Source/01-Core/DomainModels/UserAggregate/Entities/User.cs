using DomainModels.UserAggregate.Events;
using DomainModels.UserAggregate.ValueObjects;
using Framework.Entities;
using Framework.Events;
using Framework.Exceptions;

namespace DomainModels.UserAggregate.Entities;

public sealed class User : AggregateRoot<int>
{
	private User()
	{}

    public FullName FullName { get; private set; } = FullName.Default;
    public Email Email { get; private set; } = Email.Default;

    public static User Create(string fullName, string email)
	{
		var user = new User();

        user.Emit(new UserCreated
        {
            FullName = fullName,
            Email = email,
        });

        return user;
	}

	protected override void SetStateByEvent(IEvent @event)
	{
        switch (@event)
        {
            case UserCreated e:
                Id = e.Id;
                FullName = e.FullName;
                Email = e.Email;
                break;
            default:
                throw new EShopException("There is no such an event for user.");
        }
    }

	protected override void ValidateInvariants()
	{
        return;
	}
}
