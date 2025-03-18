using TodoList.Domain.Entities.Common;

#nullable disable

namespace TodoList.Domain.Entities.Task;

public class Task : BaseEntity<Guid>
{
    public Task()
    {
        Id = Guid.NewGuid();
    }

    public required string Description { get; set; }

    public required string Title { get; set; }

    public required bool IsCompleted { get; set; }

    public required DateTime DueDate { get; set; }
}
