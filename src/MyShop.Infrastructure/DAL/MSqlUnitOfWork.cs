using Microsoft.EntityFrameworkCore;

namespace MyShop.Infrastructure.DAL;

internal sealed class MSqlUnitOfWork
{
    private readonly MyShopDbContext _myShopDbContext;

    public MSqlUnitOfWork(MyShopDbContext myShopDbContext) 
        => _myShopDbContext = myShopDbContext;

    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _myShopDbContext.Database.BeginTransactionAsync();

        try
        {
            await action();
            await _myShopDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
