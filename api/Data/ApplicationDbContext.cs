using api.Configurations;
using DefaultNamespace;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ColorModel> ColorModels { get; set; }
    public DbSet<ProductItem> ProductItems { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<ProductAttributeOption> ProductAttributeOptions { get; set; }
    public DbSet<ProductAttributeType> ProductAttributeTypes { get; set; }
    public DbSet<ProductSizeVariation> ProductSizeVariations { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<SizeCategory> SizeCategories { get; set; }
    public DbSet<SizeOption> SizeOptions { get; set; }
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SizeCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SizeOptionConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSizeVariationConfiguration());
        modelBuilder.ApplyConfiguration(new ProductAttributeConfiguration());
    }
}