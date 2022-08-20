using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessBootstrapper
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        return services;
    }
}