using DomainServices.Abstractions;
using DomainServices.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DomainServices;

public static class DomainServicesBootstrapper
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IPostOfficeService, PostOfficeService>();
        services.AddScoped<IOrderService, OrderService>();
        return services;
    }
}