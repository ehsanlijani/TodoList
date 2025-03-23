using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoList.Application.DTOs.Response;
using TodoList.Application.DTOs.Task.Requests;
using TodoList.Application.Services.Interfaces.Task;
using TodoList.Application.Wrappers;
using TodoList.Domain.Contracts.Tasks;

namespace TodoList.Application.Services.Implementations.Task;

public class TaskService(ITaskRepository taskRepository, IMapper mapper) : ITaskService
{
    #region Create

    public async Task<Result<Guid>> Create(CreateTaskRequest createTaskRequest, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.Task task = mapper.Map<Domain.Entities.Task.Task>(createTaskRequest);

        bool isTaskCreated = await taskRepository.AddAsync(task, cancellationToken);

        if (isTaskCreated is false)
            return Result<Guid>.Failure(ApplicationLayerCommonMessages.Database.Failed);

        await taskRepository.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(task.Id);
    }

    #endregion Create

    #region Hard Delete

    public async Task<Result<bool>> Delete(Guid taskId, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.Task task = await taskRepository.GetById(taskId, isDelete: false, asNoTracking: false, cancellationToken);

        if (task is null)
            return Result<bool>.Failure(ApplicationLayerCommonMessages.Database.NotFount);

        taskRepository.Delete(task);

        await taskRepository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }

    #endregion Hard Delete

    #region Soft Delete

    public async Task<Result<bool>> SoftDelete(Guid taskId, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.Task task = await taskRepository.GetById(taskId, isDelete: false, asNoTracking: false, cancellationToken);

        if (task is null)
            return Result<bool>.Failure(ApplicationLayerCommonMessages.Database.NotFount);

        task.IsDelete = true;
        task.DeletedTime = DateTime.Now;

        await taskRepository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }

    #endregion Soft Delete

    #region Get All

    public async Task<Result<List<GetAllTaskDto>>> GetAll(CancellationToken cancellationToken)
    {
        List<Domain.Entities.Task.Task> taskList = await taskRepository.GetAllAsync().ToListAsync();

        return Result<List<GetAllTaskDto>>.Success(mapper.Map<List<GetAllTaskDto>>(taskList));
    }

    #endregion Get All

    #region Get By Id

    public async Task<Result<GetTaskByIdDto>> GetById(Guid taskId, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.Task task = await taskRepository.GetById(taskId, isDelete: false, asNoTracking: true, cancellationToken);

        if (task is null)
            return Result<GetTaskByIdDto>.Failure(ApplicationLayerCommonMessages.Database.NotFount);

        return Result<GetTaskByIdDto>.Success(mapper.Map<GetTaskByIdDto>(task));

    }

    #endregion Get By Id

    #region Update

    public async Task<Result<bool>> Update(Guid taskId, UpdateTaskRequest updateTaskRequest, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.Task task = await taskRepository.GetById(taskId, isDelete: false, asNoTracking: false, cancellationToken);

        if (task is null)
            return Result<bool>.Failure(ApplicationLayerCommonMessages.Database.NotFount);

        mapper.Map(updateTaskRequest, task);

        taskRepository.Update(task);

        await taskRepository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }

    #endregion Update

    #region Restore

    public async Task<Result<bool>> Restore(Guid taskId, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.Task task = await taskRepository.GetById(taskId, isDelete: true, asNoTracking: false, cancellationToken);

        if (task is null)
            return Result<bool>.Failure(ApplicationLayerCommonMessages.Database.NotFount);

        task.IsDelete = false;
        task.DeletedTime = null;

        await taskRepository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }

    #endregion Restore
}
