using Microsoft.Extensions.DependencyInjection;

namespace DomainServices;

public static class DomainServicesBootstrapper
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services;
    }
}