using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoList.Application.Services.Implementations.Task;
using TodoList.Application.Services.Interfaces.Task;

namespace TodoList.Application;

public static class ApplicationLayerConfigurations
{
    public static IServiceCollection RegisterApplicationConfigurations(this IServiceCollection services)
    {
        RegisterAutoMapper(services);

        RegisterServices(services);

        RegisterFluentValidation(services);

        return services;
    }

    #region Registrations

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }


    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITaskService, TaskService>();
    }

    private static void RegisterFluentValidation(this IServiceCollection services)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => !assembly.IsDynamic).ToArray();

        services.AddFluentValidation(config =>
        {
            foreach (var assembly in assemblies)
                config.RegisterValidatorsFromAssembly(assembly);
        });
    }

    #endregion Registrations
}
