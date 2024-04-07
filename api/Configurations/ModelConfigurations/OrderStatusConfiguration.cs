using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.Property(e => e.Status)
            .HasConversion(
                v => v.ToString(),
                v => (OrderStatusEnum)Enum.Parse(typeof(OrderStatusEnum), v));
    }
}