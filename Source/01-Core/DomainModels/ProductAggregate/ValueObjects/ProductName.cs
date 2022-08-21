using Framework.Exceptions;

namespace DomainModels.ProductAggregate.ValueObjects;

public sealed record ProductName
{
    public ProductName(string value)
    {
        Validate(value);
        Value = value;
    }

    public static ProductName Default => "Default";

    public string Value { get; private set; }

    private static void Validate(string value)
    {
        if (value is null || value.Length <= 2 || value.Length > 250)
        {
            throw new EShopException("ProductName is invalid", ExceptionStatus.InvalidArgument);
        }
    }

    public static implicit operator ProductName(string value)
    {
        return new ProductName(value);
    }

    public static implicit operator string(ProductName name)
    {
        return name.Value;
    }

    public override string ToString()
    {
        return Value;
    }
}
