using Domain.Core.Domain.Base;

namespace Infrastructure.Repositories.GenericRepository.BaseGenericRepository
{
    public interface IBaseGenericRepository<TEntity> where TEntity : BaseEntity<string>
    {
        Task<IQueryable<TEntity>> GetAllReadOnlyAsync();
        Task<IQueryable<TEntity>> GetChangeTrackingAsync();
        Task<TEntity?> GetByIdAsync(string id);
    }
}
