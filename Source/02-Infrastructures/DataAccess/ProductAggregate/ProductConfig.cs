using DomainModels.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ProductAggregate;

public sealed class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.OwnsOne(p => p.Name)
            .Property(p => p.Value)
            .HasColumnName(nameof(Product.Name));

        builder.OwnsOne(p => p.Price)
            .Property(p => p.Value)
            .HasColumnName(nameof(Product.Price));
    }
}
