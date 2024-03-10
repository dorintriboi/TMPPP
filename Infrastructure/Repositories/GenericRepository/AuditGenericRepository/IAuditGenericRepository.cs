using Domain.Core.Domain.Entities;
using Infrastructure.Repositories.GenericRepository.BaseGenericRepository;

namespace Infrastructure.Repositories.GenericRepository.AuditGenericRepository
{
    public interface IAuditGenericRepository<TEntity> : IBaseGenericRepository<TEntity> where TEntity : AuditEntity
    {
        Task UpdateAsync(TEntity obj);
        Task InsertAsync(TEntity obj);
    }
}
