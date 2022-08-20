using Microsoft.Extensions.DependencyInjection;

namespace ApplicationServices;

public static class ApplicationServicesBootstrapper
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}