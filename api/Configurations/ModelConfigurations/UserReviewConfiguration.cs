using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class UserReviewConfiguration : IEntityTypeConfiguration<UserReview>
{
    public void Configure(EntityTypeBuilder<UserReview> builder)
    {
        builder.HasOne(ur => ur.OrderLine)
            .WithMany(ol => ol.UserReviews)
            .HasForeignKey(so => so.OrderLineId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}