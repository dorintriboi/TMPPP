using Domain.Core.Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository.AuditGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository
{
    public class FullAuditGenericRepository<TEntity>
        (ApplicationDbContext context) : AuditGenericRepository<TEntity>(context), IFullAuditGenericRepository<TEntity>
        where TEntity : FullAuditEntity, new()
    {
        public async Task DeleteAsync(string id)
        {
            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                entity.DeletionTime = DateTime.UtcNow;
                entity.IsDeleted = true;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var entityDb = await context.Set<TEntity>().FirstOrDefaultAsync(x => x == entity);

            if (entityDb != null)
            {
                entityDb.IsDeleted = true;
                entityDb.DeletionTime = DateTime.UtcNow;
            }
        }
    }
}
