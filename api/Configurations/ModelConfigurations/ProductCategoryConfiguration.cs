using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasOne(pc => pc.ParentProductCategory)
            .WithMany()
            .HasForeignKey(pc => pc.ParentCategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(pc => pc.SizeCategory)
            .WithMany(sc => sc.ProductCategories)
            .HasForeignKey(pc => pc.SizeCategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}