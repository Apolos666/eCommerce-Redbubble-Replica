using api.Configurations;
using DefaultNamespace;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
    }
}