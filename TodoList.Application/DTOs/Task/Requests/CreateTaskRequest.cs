namespace TodoList.Application.DTOs.Task.Requests;

public record CreateTaskRequest(string Title, string Description, DateTime DueDate, bool IsCompleted);
