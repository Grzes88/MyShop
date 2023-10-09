using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Core.Entities;
using MyShop.Core.ValueObjects;

namespace MyShop.Infrastructure.DAL.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(pid => pid.Value, g => new ProductId(g));
        builder.Property(p => p.Name)
            .HasConversion(n => n.Value, s => new Name(s));
        builder.Property(p => p.Description)
            .HasConversion(d => d.Value, s => new Description(s));
        builder.Property(p => p.Price)
            .HasConversion(p => p.Value, d => new Price(d));
    }
}
