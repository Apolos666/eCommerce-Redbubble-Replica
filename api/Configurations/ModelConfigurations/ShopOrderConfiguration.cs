using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class ShopOrderConfiguration : IEntityTypeConfiguration<ShopOrder>
{
    public void Configure(EntityTypeBuilder<ShopOrder> builder)
    {
        builder.HasOne(so => so.PaymentMethod)
            .WithMany(upm => upm.ShopOrders)
            .HasForeignKey(so => so.PaymentMethodId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}