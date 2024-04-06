using System.Text;
using api.Configurations;
using api.Data;
using api.Helper;
using api.Models.Identity;
using api.Models.Identity.Authentication;
using api.Models.TypeSafe;
using api.Repositories.AttributeTypeModel;
using api.Repositories.ColorModel;
using api.Repositories.PaymentType;
using api.Repositories.Product;
using api.Repositories.ProductAttributeModel;
using api.Repositories.ProductAttributeOptionModel;
using api.Repositories.ProductCategory;
using api.Repositories.ProductImage;
using api.Repositories.ProductItem;
using api.Repositories.ProductSizeVariation;
using api.Repositories.SizeCategory;
using api.Repositories.SizeOption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            .AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();

        return service;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection service)
    {
        service.AddScoped<IAuthenticationService, AuthenticationService>();

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
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static IServiceCollection AddApplicationJwtAuthentication(this IServiceCollection service,
        JwtConfiguration jwtConfig)
    {
        service
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
                };
            });

        return service;
    }

    public static IServiceCollection AddApplicationAuthorization(this IServiceCollection service)
    {
        service.AddAuthorization(options =>
        {
            options.AddPolicy(TypeSafe.Policies.PaymentTypePolicy, policy =>
            {
                policy.RequireRole(TypeSafe.Roles.Admin);
                policy.RequireClaim(TypeSafe.Controller.PaymentType,
                    TypeSafe.GetAdminPermissions());
            });

            // Calim-based authorization
            // StudentController
            options.AddPolicy(TypeSafe.Policies.FullControlPolicy,
                policy => { policy.RequireClaim(TypeSafe.Controller.Product); });

            options.AddPolicy(TypeSafe.Policies.ReadAndWritePolicy, policy =>
            {
                policy.RequireClaim(TypeSafe.Controller.ProductItem,
                    TypeSafe.Permissions.Read.ToString(),
                    TypeSafe.Permissions.Write.ToString());
            });

            // // Calim-based authorization using value
            // // StudentController
            // options.AddPolicy(TypeSafe.Policies.FullControlPolicy, policy =>
            // {
            //     policy.RequireClaim(TypeSafe.Controller.Student,
            //         TypeSafe.Permissions.Delete.ToString(),
            //         TypeSafe.Permissions.Update.ToString());
            // });
            //
            // options.AddPolicy(TypeSafe.Policies.ReadAndWritePolicy, policy =>
            // {
            //     policy.RequireClaim(TypeSafe.Controller.Student,
            //         TypeSafe.Permissions.Write.ToString());
            // });
            //
            // options.AddPolicy(TypeSafe.Policies.ReadPolicy, policy =>
            // {
            //     policy.RequireClaim(TypeSafe.Controller.Student,
            //         TypeSafe.Permissions.Read.ToString());
            // });
        });

        return service;
    }

    public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddSwaggerGen();

        return services;
    }

    public static async Task<IApplicationBuilder> SeedDataAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationIdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Delete all data in AspNetUserClaims, AspNetUsers, AspNetUserRoles
            applicationDbContext.UserClaims.RemoveRange(applicationDbContext.UserClaims);
            applicationDbContext.Users.RemoveRange(applicationDbContext.Users);
            applicationDbContext.UserRoles.RemoveRange(applicationDbContext.UserRoles);
            await applicationDbContext.SaveChangesAsync();

            // if (!userManager.Users.Any())
            // {
            // Creating User Entities
            var adminUser = new ApplicationIdentityUser() { UserName = "admin", Email = "admin@test.com" };
            var contributorUser = new ApplicationIdentityUser() { UserName = "cont", Email = "c@test.com" };
            var user = new ApplicationIdentityUser() { UserName = "user", Email = "user@test.com" };

            // Creating Role Entities
            var adminRole = new IdentityRole(TypeSafe.Roles.Admin);
            var contributorRole = new IdentityRole(TypeSafe.Roles.Contributor);
            var userRole = new IdentityRole(TypeSafe.Roles.User);

            // Adding Roles
            await roleManager.CreateAsync(adminRole);
            await roleManager.CreateAsync(contributorRole);
            await roleManager.CreateAsync(userRole);

            // Adding Users with Password
            await userManager.CreateAsync(adminUser, "123456");
            await userManager.CreateAsync(contributorUser, "123456");
            await userManager.CreateAsync(user, "123456");

            // Ading Claims to Users
            // Ading Claims to Users
            await userManager.AddClaimAsync(adminUser,
                AuthorizationHelper.GetAdminClaims(TypeSafe.Controller.PaymentType));
            await userManager.AddClaimAsync(contributorUser,
                AuthorizationHelper.GetcontributorClaims(TypeSafe.Controller.Product));
            await userManager.AddClaimAsync(user, AuthorizationHelper.GetUserClaims(TypeSafe.Controller.Product));

            // Adding Roles to Users
            await userManager.AddToRoleAsync(adminUser, TypeSafe.Roles.Admin);
            await userManager.AddToRoleAsync(contributorUser, TypeSafe.Roles.Contributor);
            await userManager.AddToRoleAsync(user, TypeSafe.Roles.User);
            // }
        }

        return app;
    }
}