using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Core.Entities;
using MyShop.Core.ValueObjects;

namespace MyShop.Infrastructure.DAL.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasConversion(cid => cid.Value, g => new CategoryId(g));
        builder.Property(c => c.Name)
            .IsRequired()
            .HasConversion(n => n.Value, s => new Name(s));
    }
}
