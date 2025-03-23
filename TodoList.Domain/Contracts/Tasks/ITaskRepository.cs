using TodoList.Domain.Contracts.Common;

namespace TodoList.Domain.Contracts.Tasks;

public interface ITaskRepository : IGenericRepository<Entities.Task.Task>
{
    Task<Domain.Entities.Task.Task?> GetById(Guid id, bool isDelete = false, bool asNoTracking = false, CancellationToken cancellationToken = default);
}

