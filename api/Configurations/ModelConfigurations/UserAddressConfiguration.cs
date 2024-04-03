using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(ua => new { ua.IdentityUserId, ua.AddressModelId });
        builder.HasIndex(ua => new { ua.IdentityUserId, ua.AddressModelId }).IsUnique();

        builder.HasOne(ua => ua.IdentityUser)
            .WithMany(aiu => aiu.UserAddresses)
            .HasForeignKey(aiu => aiu.IdentityUserId);
        
        builder.HasOne(ua => ua.AddressModel)
            .WithMany(am => am.UserAddresses)
            .HasForeignKey(ua => ua.AddressModelId);
    }
}