using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Contracts.Tasks;
using TodoList.Infrastructure.Persistence.Context;
using TodoList.Infrastructure.Persistence.Repositories.Common;

namespace TodoList.Infrastructure.Persistence.Repositories.Tasks;

public class TaskRepository(TodoListDBContext todoListDBContext) :
    GenericRepository<Domain.Entities.Task.Task>(todoListDBContext), ITaskRepository
{
    private readonly TodoListDBContext _todoListDBContext = todoListDBContext;

    public async Task<Domain.Entities.Task.Task?> GetById(
        Guid id,
        bool isDelete = false,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        )
    {
        IQueryable<Domain.Entities.Task.Task> query = _todoListDBContext.Tasks;

        if (isDelete is true)
            query = query.Where(task => task.IsDelete.Equals(true));

        else
            query = query.Where(task => task.IsDelete.Equals(false));

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.SingleOrDefaultAsync(task => task.Id == id, cancellationToken);
    }
}
