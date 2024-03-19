using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class ProductAttributeTypeConfiguration : IEntityTypeConfiguration<ProductAttributeType>
{
    public void Configure(EntityTypeBuilder<ProductAttributeType> builder)
    {
        builder.HasIndex(c => c.AttributeName)
            .IsUnique();
    }
}