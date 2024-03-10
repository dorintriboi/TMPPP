using Domain.Core.Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository.BaseGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenericRepository.AuditGenericRepository
{
    public class AuditGenericRepository<TEntity>
        (ApplicationDbContext context) : BaseGenericRepository<TEntity>(context), IAuditGenericRepository<TEntity>
        where TEntity : AuditEntity, new()
    {
        public async Task InsertAsync(TEntity obj)
        {
            obj.CreationTime = DateTime.UtcNow;

            await context.Set<TEntity>().AddAsync(obj);
        }

        public Task UpdateAsync(TEntity obj)
        {
            obj.LastModificationTime = DateTime.UtcNow;

            context.Entry(obj).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
