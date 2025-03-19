using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Profiles;

namespace TodoList.Application;

public static class ApplicationLayerConfigurations
{
    public static IServiceCollection RegisterApplicationConfigurations(this IServiceCollection services)
    {
        RegisterAutoMapper(services);

        return services;
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TaskProfile).Assembly);
    }
}
