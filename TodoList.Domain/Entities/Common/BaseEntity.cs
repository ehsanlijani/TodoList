namespace TodoList.Domain.Entities.Common;

#nullable enable

public class BaseEntity<T>
{
    public required T Id { get; set; }

    public DateTime? DeletedTime { get; set; }

    public bool IsDeleted
    {
        get
        {
            if (DeletedTime is not null || DeletedTime != DateTime.MinValue)
                return true;

            else
                return false;
        }
    }

    public required DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }
}
