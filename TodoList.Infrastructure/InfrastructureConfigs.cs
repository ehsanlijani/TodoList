using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Infrastructure.Persistence.Context;

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

        return services;
    }
}
