using Domain.Core.Domain.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenericRepository.BaseGenericRepository
{
    public class BaseGenericRepository<TEntity>(ApplicationDbContext context) : IBaseGenericRepository<TEntity>
        where TEntity : BaseEntity<string>, new()
    {
        public Task<IQueryable<TEntity>> GetAllReadOnlyAsync()
        {
            return Task.FromResult(context.Set<TEntity>().AsNoTracking().AsQueryable());
        }
        
        public Task<IQueryable<TEntity>> GetChangeTrackingAsync()
        {
            return Task.FromResult(context.Set<TEntity>().AsTracking().AsQueryable());
        }

        public async Task<TEntity?> GetByIdAsync(string id)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
