using System.Text;
using api.Data;
using api.Extensions;
using api.Models.Identity;
using api.Models.Identity.Authentication;
using api.Models.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace api.Services.ServicesRegistration;

public static class SecurityService
{
    public static IdentityBuilder AddApplicationIdentity(this IServiceCollection services)
    {
        return services.AddDefaultIdentity<ApplicationIdentityUser>(options =>
            {
                // Sign in settings
                options.SignIn.RequireConfirmedAccount = false;

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
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
            options.AddPaymentPolicies();
            options.AddOrderPolicies();

            // // Calim-based authorization
            // // StudentController
            // options.AddPolicy(TypeSafe.Policies.FullControlPolicy,
            //     policy => { policy.RequireClaim(TypeSafe.Controller.Product); });
            //
            // options.AddPolicy(TypeSafe.Policies.ReadAndWritePolicy, policy =>
            // {
            //     policy.RequireClaim(TypeSafe.Controller.ProductItem,
            //         TypeSafe.Permissions.Read.ToString(),
            //         TypeSafe.Permissions.Write.ToString());
            // });

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

    public static IServiceCollection AddCorsService(this IServiceCollection service, CorsConfig corsConfig)
    {
        service.AddCors(options =>
        {
            options.AddPolicy(corsConfig.PolicyName, builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(corsConfig.OriginUrl)
                    .AllowCredentials();
            });
        });

        return service;
    }
}