namespace TodoList.Application.DTOs.Task.Requests;

public record UpdateTaskRequest(string Title, string Description, DateTime DueDate, bool IsCompleted);
