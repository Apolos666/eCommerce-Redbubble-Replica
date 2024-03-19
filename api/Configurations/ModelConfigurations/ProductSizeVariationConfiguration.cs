using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class ProductSizeVariationConfiguration : IEntityTypeConfiguration<ProductSizeVariation>
{
    public void Configure(EntityTypeBuilder<ProductSizeVariation> builder)
    {
        builder.HasKey(psv => new { psv.ProductItemId, psv.SizeOptionsId });

        builder.HasOne(psv => psv.ProductItem)
            .WithMany(pi => pi.ProductSizeVariations)
            .HasForeignKey(psv => psv.ProductItemId);
        
        builder.HasOne(psv => psv.SizeOption)
            .WithMany(so => so.ProductSizeVariations)
            .HasForeignKey(psv => psv.SizeOptionsId);
    }
}