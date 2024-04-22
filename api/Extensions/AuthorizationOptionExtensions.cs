using api.Infrastructure.Authorization.Requirements.PaymentTypePolicy;
using api.Models.TypeSafe;
using Microsoft.AspNetCore.Authorization;

namespace api.Extensions;

public static class AuthorizationOptionExtensions
{
    public static void AddPaymentPolicies(this AuthorizationOptions options)
    {
        options.AddPolicy(TypeSafe.Policies.PaymentTypePolicy, policy =>
        {
            policy.Requirements.Add(new PaymentTypeRequirements());
        });
        
        options.AddPolicy(TypeSafe.Policies.UserPaymentMethod, policy =>
        {
            policy.RequireAssertion(context => context.User.IsInRole(TypeSafe.Roles.Admin) || context.User.IsInRole(TypeSafe.Roles.User));
            policy.RequireClaim(TypeSafe.Controller.UserPaymentMethod,
                TypeSafe.GetAdminPermissions());
        });
    }
    
    public static void AddOrderPolicies(this AuthorizationOptions options)
    {
        options.AddPolicy(TypeSafe.Policies.ShippingMethodPolicy, policy =>
        {
            policy.RequireRole(TypeSafe.Roles.Admin);
            policy.RequireClaim(TypeSafe.Controller.ShippingMethod,
                TypeSafe.GetAdminPermissions());
        });
        
        options.AddPolicy(TypeSafe.Policies.OrderStatus, policy =>
        {
            policy.RequireRole(TypeSafe.Roles.Admin);
            policy.RequireClaim(TypeSafe.Controller.OrderStatus,
                TypeSafe.GetAdminPermissions());
        });
    }
}