using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using TodoList.Domain.Contracts.Common;
using TodoList.Infrastructure.Persistence.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TodoList.Infrastructure.Persistence.Repositories.Common;

public class GenericRepository<TEntity>(TodoListDBContext dbContext) : IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public IQueryable<TEntity> GetAllAsync(bool isDelete = false, bool asNoTracking = false)
    {
        IQueryable<TEntity>? data = _dbSet.AsNoTracking().AsQueryable();

        if (isDelete is true)
            data = data.Where(entity => EF.Property<bool>(entity, "IsDelete"));

        else
            data = data.Where(entity => !EF.Property<bool>(entity, "IsDelete"));

        if (asNoTracking)
            data = data.AsNoTracking();

        return data;
    }

    public async Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        EntityEntry result = await _dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(true);
        return result.State == EntityState.Added;
    }

    public bool Update(TEntity entity)
    {
        EntityEntry result = _dbSet.Update(entity);
        return result.State == EntityState.Modified;
    }

    public bool Delete(TEntity entity)
    {
        EntityEntry result = _dbSet.Remove(entity);
        return result.State == EntityState.Deleted;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

}

