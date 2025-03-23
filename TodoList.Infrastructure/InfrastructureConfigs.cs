using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Domain.Contracts.Common;
using TodoList.Infrastructure.Persistence.Context;
using TodoList.Infrastructure.Persistence.Repositories.Common;

namespace TodoList.Infrastructure;

public static class InfrastructureConfigs
{
    public static IServiceCollection RegisterInfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        #region Context

        services.AddDbContext<TodoListDBContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("TodoListContext"));
        });

        #endregion Context

        #region Repositories

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        var assembly = typeof(InfrastructureConfigs).Assembly;

        var repositoryTypes = assembly.GetTypes()
            .Where(t => !t.IsInterface && !t.IsAbstract)
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGenericRepository<>)))
            .Select(t => new
            {
                ImplementationType = t,
                InterfaceType = t.GetInterfaces().FirstOrDefault(i => !i.IsGenericType)
            })
            .Where(t => t.InterfaceType is not null);

        foreach (var repository in repositoryTypes)
        {
            services.AddScoped(repository.InterfaceType, repository.ImplementationType);
        }

        #endregion

        return services;
    }
}
