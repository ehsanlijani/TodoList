namespace TodoList.Application.DTOs.Response;

#nullable enable

public record GetAllTaskDto(
    string Title,
    string Description,
    bool IsCompleted,
    DateTime DueDate,
    DateTime? ModifiedAt,
    DateTime CreatedAt,
    bool IsDeleted);


