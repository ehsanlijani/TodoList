namespace TodoList.Domain.Entities.Common;

#nullable enable

public class BaseEntity<T>
{
    public required T Id { get; set; }

    public DateTime? DeletedTime { get; set; }

    public bool IsDelete { get; set; }

    public required DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }
}
