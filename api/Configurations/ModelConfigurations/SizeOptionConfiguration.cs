using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class SizeOptionConfiguration : IEntityTypeConfiguration<SizeOption>
{
    public void Configure(EntityTypeBuilder<SizeOption> builder)
    {
        builder.HasOne(so => so.SizeCategory)
            .WithMany(sc => sc.SizeOptions)
            .HasForeignKey(so => so.SizeCategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}