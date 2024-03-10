using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories.UnitOfWorkRepository;

public class UnitOfWork(ApplicationDbContext context)
    : IUnitOfWork
{
    private IDbContextTransaction dbContextTransaction;
    
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }

    public async Task CommitAsync()
    {
        await dbContextTransaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await dbContextTransaction.RollbackAsync();
    }

    public async Task StartTransactionAsync()
    {
        if (dbContextTransaction is null)
        {
            dbContextTransaction = await context.Database.BeginTransactionAsync();    
        }
    }

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}