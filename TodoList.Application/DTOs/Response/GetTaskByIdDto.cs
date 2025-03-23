namespace TodoList.Application.DTOs.Response;

public record GetTaskByIdDto(
    string Title,
    string Description,
    bool IsCompleted,
    DateTime DueDate,
    DateTime ModifiedAt,
    DateTime CreatedAt);
