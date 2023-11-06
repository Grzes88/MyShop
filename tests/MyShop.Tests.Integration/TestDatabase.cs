using MyShop.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace MyShop.Tests.Integration;

internal sealed class TestDatabase : IDisposable
{
    public MyShopDbContext DbContext { get; }

    public TestDatabase()
    {
        var options = new OptionsProvider().Get<MSqlOptions>("MSql");
        DbContext = new MyShopDbContext(new DbContextOptionsBuilder<MyShopDbContext>().UseSqlServer(options.ConnectionString).Options);
    }

    public void Dispose()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
    }
}
