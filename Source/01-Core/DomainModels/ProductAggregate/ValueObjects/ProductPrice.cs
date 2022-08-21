using Framework.Exceptions;

namespace DomainModels.ProductAggregate.ValueObjects;

public sealed record ProductPrice
{
    public ProductPrice(ulong value)
    {
        Validate(value);
        Value = value;
    }

    public static ProductPrice Default => 1000;

    public ulong Value { get; private set; }

    private static void Validate(ulong value)
    {
        if (value < 1000)
        {
            throw new EShopException("ProductPrice is invalid", ExceptionStatus.InvalidArgument);
        }
    }

    public static implicit operator ProductPrice(ulong value)
    {
        return new ProductPrice(value);
    }

    public static implicit operator ulong(ProductPrice price)
    {
        return price.Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}