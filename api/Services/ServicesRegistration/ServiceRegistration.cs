using api.Configurations;
using api.Data;
using api.Infrastructure.Authorization.Requirements.PaymentTypePolicy;
using api.Repositories.AttributeTypeModel;
using api.Repositories.ColorModel;
using api.Repositories.Order_Repositories.OrderStatus;
using api.Repositories.Payment_Repositories.UserPaymentMethod;
using api.Repositories.PaymentType;
using api.Repositories.Product;
using api.Repositories.ProductAttributeModel;
using api.Repositories.ProductAttributeOptionModel;
using api.Repositories.ProductCategory;
using api.Repositories.ProductImage;
using api.Repositories.ProductItem;
using api.Repositories.ProductSizeVariation;
using api.Repositories.ShippingMethod;
using api.Repositories.SizeCategory;
using api.Repositories.SizeOption;
using api.Repositories.User_Repositories.UserImage;
using api.Services.AzureServices;
using api.Services.AzureServices.BlobStrorage;
using api.Services.AzureServices.BlobStrorage.UserProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationRepositories(this IServiceCollection service,
        DatabaseConfig? databaseConfig)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(databaseConfig.ConnectionString);
            options.EnableDetailedErrors(databaseConfig.DetailedErrors); // DetailedErrors is true in development
            options.EnableSensitiveDataLogging(databaseConfig
                .SensitiveDataLogging); // SensitiveDataLogging is true in development
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
            .AddScoped<IProductAttributeRepository, ProductAttributeRepository>()
            .AddScoped<IPaymentTypeRepository, PaymentTypeRepository>()
            .AddScoped<IShippingMethodRepository, ShippingMethodReopository>()
            .AddScoped<IOrderStatusRepository, OrderStatusRepository>()
            .AddScoped<IUserPaymentMethodRepository, UserPaymentMethodRepository>()
            .AddScoped<IUserImageRepository, UserImageRepository>();

        service.AddScoped<IBlobServices, BlobServices>()
            .AddScoped<IUserProfileBlobServices, UserProfileBlobServices>();
        

        return service;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection service)
    {
        service.AddScoped<IAuthenticationService, AuthenticationService>();

        return service;
    }

    public static IServiceCollection AddRequirementHandler(this IServiceCollection service)
    {
        service.AddSingleton<IAuthorizationHandler, PaymentTypeRequirementHandler>();

        return service;
    }

    public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddSwaggerGen();
        services.AddAzureServices();
        
        return services;
    }

    
}