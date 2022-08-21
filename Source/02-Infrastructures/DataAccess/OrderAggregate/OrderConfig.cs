using DomainModels.OrderAggregate.Entities;
using DomainModels.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.OrderAggregate;

public sealed class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(o => o.UserId);

        builder.OwnsOne(o => o.Description)
            .Property(o => o.Value)
            .HasColumnName(nameof(Order.Description));

        builder.OwnsMany(o => o.OrderLines);
    }
}
