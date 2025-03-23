namespace TodoList.Domain.Contracts.Common;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAllAsync(bool isDelete = false, bool asNoTracking = false);

    Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken);

    bool Update(TEntity entity);

    bool Delete(TEntity entity);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}

