﻿using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations;

public class ColorModelConfiguration : IEntityTypeConfiguration<ColorModel>
{
    public void Configure(EntityTypeBuilder<ColorModel> builder)
    {
        builder.HasIndex(c => c.ColorName)
            .IsUnique();
    }
}