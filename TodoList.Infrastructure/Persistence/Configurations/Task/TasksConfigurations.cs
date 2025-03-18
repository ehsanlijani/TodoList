using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoList.Infrastructure.Persistence.Configurations.Task;

public class TasksConfigurations : IEntityTypeConfiguration<Domain.Entities.Task.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Task.Task> builder)
    {
        builder.HasKey(p => p.Id).IsClustered();

        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);
    }
}
