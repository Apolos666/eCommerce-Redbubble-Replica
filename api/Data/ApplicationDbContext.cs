using api.Configurations;
using api.Models;
using api.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser>
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
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<AddressModel> AddressModels { get; set; } 
    public DbSet<Country> Countries { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<UserReview> UserReviews { get; set; }
    public DbSet<ShopOrder> ShopOrders { get; set; }
    public DbSet<ShippingMethod> ShippingMethods { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ColorModelConfiguration());
        modelBuilder.ApplyConfiguration(new ProductAttributeTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SizeCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SizeOptionConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSizeVariationConfiguration());
        modelBuilder.ApplyConfiguration(new ProductAttributeConfiguration());
        modelBuilder.ApplyConfiguration(new UserAddressConfiguration());
        modelBuilder.ApplyConfiguration(new ShopOrderConfiguration());
        modelBuilder.ApplyConfiguration(new UserReviewConfiguration());
    }
}