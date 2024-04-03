using api.Configurations;
using api.Data;
using api.Models.Identity;
using api.Repositories.AttributeTypeModel;
using api.Repositories.ColorModel;
using api.Repositories.Product;
using api.Repositories.ProductAttributeModel;
using api.Repositories.ProductAttributeOptionModel;
using api.Repositories.ProductCategory;
using api.Repositories.ProductImage;
using api.Repositories.ProductItem;
using api.Repositories.ProductSizeVariation;
using api.Repositories.SizeCategory;
using api.Repositories.SizeOption;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection service,
        DatabaseConfig? databaseConfig)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(databaseConfig.ConnectionString);
            options.EnableDetailedErrors(databaseConfig.DetailedErrors); // DetailedErrors is true in development
            options.EnableSensitiveDataLogging(databaseConfig.SensitiveDataLogging); // SensitiveDataLogging is true in development
        });
        
        service.AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
            .AddScoped<IColorModelRepository, ColorModelRepository>()
            .AddScoped<IProductAttributeTypeRepository, ProductAttributeTypeRepository>()
            .AddScoped<IProductAttributeOptionRepository, ProductAttributeOptionRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProductItemRepository, ProductItemRepository>()
            .AddScoped<IProductImageRepository, ProductImageRepository>()
            .AddScoped<ISizeCategoryRepository, SizeCategoryRepository>()
            .AddScoped<ISizeOptionRepository, SizeOptionRepository>()
            .AddScoped<IProductSizeVariationRepository, ProductSizeVariationRepository>()
            .AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
        
        return service;
    }
    
    public static IdentityBuilder AddApplicationIdentity(this IServiceCollection services)
    {
        return services.AddDefaultIdentity<ApplicationIdentityUser>(options =>
            {
                // Sign in settings
                options.SignIn.RequireConfirmedAccount = true;
                
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                
                // User settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }
    
    public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddSwaggerGen();
        
        return services;
    }
}