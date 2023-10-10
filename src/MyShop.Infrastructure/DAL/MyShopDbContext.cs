using Microsoft.EntityFrameworkCore;
using MyShop.Core.Entities;

namespace MyShop.Infrastructure.DAL;

public sealed class MyShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public MyShopDbContext(DbContextOptions<MyShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
