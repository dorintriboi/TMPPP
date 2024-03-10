using Domain.Core.Domain.Entities;
using Infrastructure.Repositories.GenericRepository.AuditGenericRepository;

namespace Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository
{
    public interface IFullAuditGenericRepository<TEntity> : IAuditGenericRepository<TEntity> where TEntity : FullAuditEntity
    {
        Task DeleteAsync(string id);
        Task DeleteAsync(TEntity entity);
    }
}
