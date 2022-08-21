using ApplicationServices.Queries;
using ApplicationServices.Utility;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationServices;

public static class ApplicationServicesBootstrapper
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddMediatR(typeof(GetUsersQuery).GetTypeInfo().Assembly);

        return services;
    }
}