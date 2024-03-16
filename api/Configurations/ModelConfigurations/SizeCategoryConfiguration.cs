using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class SizeCategoryConfiguration : IEntityTypeConfiguration<SizeCategory>
{
    public void Configure(EntityTypeBuilder<SizeCategory> builder)
    {
        // builder.HasMany(sc => sc.ProductCategories)
        //     .WithOne(pc => pc.SizeCategory)
        //     .OnDelete(DeleteBehavior.NoAction);
        //
        // builder.HasMany(sc => sc.SizeOptions)
        //     .WithOne(so => so.SizeCategory)
        //     .OnDelete(DeleteBehavior.NoAction);
    }
}