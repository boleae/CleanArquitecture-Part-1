using System.Runtime.CompilerServices;
using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TEntityId>
where TEntity : Entity<TEntityId>
where TEntityId : class
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken)
    {
        return await DbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public virtual void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }
}