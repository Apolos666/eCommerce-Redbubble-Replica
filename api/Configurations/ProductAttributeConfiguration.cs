using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.HasKey(pa => new { pa.ProductId, pa.ProductAttributeOptionId });
        
        builder.HasOne(pa => pa.Product)
            .WithMany(p => p.ProductAttributes)
            .HasForeignKey(pa => pa.ProductId);

        builder.HasOne(pa => pa.ProductAttributeOption)
            .WithMany(pao => pao.ProductAttributes)
            .HasForeignKey(pa => pa.ProductAttributeOptionId);
    }
}