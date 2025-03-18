using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TodoList.Infrastructure.Persistence.Context;

public class TodoListDBContext(DbContextOptions<TodoListDBContext> options) : DbContext(options)
{
    public DbSet<Domain.Entities.Task.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
