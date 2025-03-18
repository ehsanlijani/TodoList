using TodoList.Domain.Entities.Common;

#nullable disable

namespace TodoList.Domain.Entities;

public class Task : BaseEntity<Guid>
{
    public required string Description { get; set; }

    public required string Title { get; set; }

    public required bool IsCompleted { get; set; }

    public required DateTime DueDate { get; set; }
}
