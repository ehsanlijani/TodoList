using TodoList.Application.DTOs.Response;
using TodoList.Application.DTOs.Task.Requests;
using TodoList.Application.Wrappers;

namespace TodoList.Application.Services.Interfaces.Task;

public interface ITaskService
{
    Task<Result<List<GetAllTaskDto>>> GetAll(CancellationToken cancellationToken);

    Task<Result<GetTaskByIdDto>> GetById(Guid taskId, CancellationToken cancellationToken);

    Task<Result<Guid>> Create(CreateTaskRequest createTaskRequest, CancellationToken cancellationToken);

    Task<Result<bool>> Update(Guid taskId, UpdateTaskRequest updateTaskRequest, CancellationToken cancellationToken);

    Task<Result<bool>> Delete(Guid taskId, CancellationToken cancellationToken);

    Task<Result<bool>> SoftDelete(Guid taskId, CancellationToken cancellationToken);

    Task<Result<bool>> Restore(Guid taskId, CancellationToken cancellationToken);
}
