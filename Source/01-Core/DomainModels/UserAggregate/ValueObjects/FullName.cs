using Framework.Exceptions;

namespace DomainModels.UserAggregate.ValueObjects;

public sealed record FullName
{
    public FullName(string value)
    {
        Validate(value);
        Value = value;
    }

    public string Value { get; private set; }

    public static FullName Default => "Default";

    private static void Validate(string value)
    {
        if (value is null || value.Length <= 2 || value.Length > 200)
        {
            throw new EShopException("Name is invalid", ExceptionStatus.InvalidArgument);
        }
    }

    public static implicit operator FullName(string value)
    {
        return new FullName(value);
    }

    public static implicit operator string(FullName name)
    {
        return name.Value;
    }

    public override string ToString()
    {
        return Value;
    }
}