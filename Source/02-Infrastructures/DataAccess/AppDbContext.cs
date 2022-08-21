using DomainModels.OrderAggregate.Entities;
using DomainModels.ProductAggregate.Entities;
using DomainModels.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Orders = Set<Order>();
        Products = Set<Product>();
        Users = Set<User>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
}

