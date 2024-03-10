namespace Infrastructure.Repositories.AccountRepository.AccountGenericRepository;

public interface IAccountGenericRepository
{
    Task<string> GetAccountIdAsync(string userId);
    Task InsertAccountAsync<TEntity>(TEntity entity);
}