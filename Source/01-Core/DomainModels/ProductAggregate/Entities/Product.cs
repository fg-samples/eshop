using DomainModels.ProductAggregate.Events;
using DomainModels.ProductAggregate.ValueObjects;
using Framework.Entities;
using Framework.Events;
using Framework.Exceptions;

namespace DomainModels.ProductAggregate.Entities;

public sealed class Product : AggregateRoot<int>
{
    private Product()
    { }

    public ProductName Name { get; private set; } = ProductName.Default;
    public ProductPrice Price { get; private set; } = ProductPrice.Default;
    public bool IsBreakable { get; private set; }

    public static Product Create(string name, ulong price, bool isBreakable)
    {
        var product = new Product();

        product.Emit(new ProductCreated
        {
            Name = name,
            Price = price,
            IsBreakable = isBreakable,
        });

        return product;
    }

    protected override void SetStateByEvent(IEvent @event)
    {
        switch (@event)
        {
            case ProductCreated e:
                Id = e.Id;
                Name = e.Name;
                Price = e.Price;
                IsBreakable = e.IsBreakable;
                break;
            default:
                throw new EShopException("There is no such an event for product.");
        }
    }

    protected override void ValidateInvariants()
    {
        return;
    }
}
