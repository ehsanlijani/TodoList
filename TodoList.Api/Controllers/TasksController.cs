using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTOs.Response;
using TodoList.Application.DTOs.Task.Requests;
using TodoList.Application.Services.Interfaces.Task;
using TodoList.Application.Wrappers;

namespace TodoList.Api.Controllers;

public class TasksController(ITaskService taskService) : BaseController
{
    #region Get All

    [HttpGet]
    [ProducesResponseType(typeof(List<GetAllTaskDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        Result<List<GetAllTaskDto>> tasks = await taskService.GetAll(cancellationToken);

        if (tasks.IsSuccess)
            return Ok(tasks.Value);

        return BadRequest(tasks);
    }

    #endregion Get All

    #region Get By Id

    [HttpGet("{taskId}")]
    [ProducesResponseType(typeof(GetTaskByIdDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Result<>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(Guid taskId, CancellationToken cancellationToken)
    {
        Result<GetTaskByIdDto> task = await taskService.GetById(taskId, cancellationToken);

        if (task.IsSuccess)
            return Ok(task.Value);

        return NotFound(task);
    }

    #endregion Get By Id

    #region Create

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Result<>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateTaskRequest createTaskRequest, CancellationToken cancellationToken)
    {
        Result<Guid> task = await taskService.Create(createTaskRequest, cancellationToken);

        if (task.IsSuccess)
            return CreatedAtAction(nameof(GetById), new { taskId = task.Value }, task.Value);

        return BadRequest(task);
    }

    #endregion Create

    #region Update

    [HttpPut("{taskId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid taskId, [FromBody] UpdateTaskRequest updateTaskRequest, CancellationToken cancellationToken)
    {
        Result<bool> task = await taskService.Update(taskId, updateTaskRequest, cancellationToken);

        if (task.IsSuccess)
            return NoContent();

        return NotFound(task);
    }

    #endregion

    #region Delete

    [HttpDelete("{taskId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid taskId, CancellationToken cancellationToken)
    {
        Result<bool> task = await taskService.Delete(taskId, cancellationToken);

        if (task.IsSuccess)
            return NoContent();

        return BadRequest(task);
    }

    #endregion

    #region Soft Delete

    [HttpPatch("{taskId}/SoftDelete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SoftDelete(Guid taskId, CancellationToken cancellationToken)
    {
        Result<bool> task = await taskService.SoftDelete(taskId, cancellationToken);

        if (task.IsSuccess)
            return NoContent();

        return BadRequest(task);
    }

    #endregion Soft Delete

    #region Restore

    [HttpPatch("{taskId}/restore")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Restore(Guid taskId, CancellationToken cancellationToken)
    {
        Result<bool> task = await taskService.Restore(taskId, cancellationToken);

        if (task.IsSuccess)
            return NoContent();

        return BadRequest(task);
    }

    #endregion Restore
}
