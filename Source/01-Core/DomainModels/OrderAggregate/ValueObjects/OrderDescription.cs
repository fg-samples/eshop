using Framework.Exceptions;

namespace DomainModels.OrderAggregate.ValueObjects;

public sealed record OrderDescription
{
    public OrderDescription(string value)
    {
        Validate(value);
        Value = value;
    }

    public string Value { get; private set; }

    public static OrderDescription Default => new("Default description");

    private static void Validate(string value)
    {
        if (value is null || value.Length <= 10 || value.Length > 300)
        {
            throw new EShopException("OrderDescription is invalid", ExceptionStatus.InvalidArgument);
        }
    }

    public static implicit operator OrderDescription(string value)
    {
        return new OrderDescription(value);
    }

    public static implicit operator string(OrderDescription description)
    {
        return description.Value;
    }

    public override string ToString()
    {
        return Value;
    }
}
