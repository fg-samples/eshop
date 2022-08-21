using DomainModels.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.UserAggregate;

public sealed class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.OwnsOne(u => u.FullName)
            .Property(u => u.Value)
            .HasColumnName(nameof(User.FullName))
            .IsRequired();

        builder.OwnsOne(u => u.Email)
            .Property(u => u.Value)
            .HasColumnName(nameof(User.Email))
            .IsRequired();
    }
}
