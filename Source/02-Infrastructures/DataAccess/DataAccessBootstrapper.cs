using DataAccess.OrderAggregate;
using DataAccess.ProductAggregate;
using DataAccess.UserAggregate;
using DomainModels.OrderAggregate.Data;
using DomainModels.ProductAggregate.Data;
using DomainModels.UserAggregate.Data;
using Framework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessBootstrapper
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(
            //opt => opt.UseInMemoryDatabase("EShop")
            opt => opt.UseSqlServer(connectionString)
        );

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, AppUnitOfWork>();

        return services;
    }
}