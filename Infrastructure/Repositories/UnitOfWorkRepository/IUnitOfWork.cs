namespace Infrastructure.Repositories.UnitOfWorkRepository;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task StartTransactionAsync();
}