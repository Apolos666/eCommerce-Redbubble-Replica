using api.Models.TypeSafe;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace api.Infrastructure.Authorization.Requirements.PaymentTypePolicy;

public class PaymentTypeRequirements : IAuthorizationRequirement
{
    
}

public class PaymentTypeRequirementHandler : AuthorizationHandler<PaymentTypeRequirements>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PaymentTypeRequirements requirement)
    {
        var claims = context.User.Claims;

        var role = claims.FirstOrDefault(c => c.Type == TypeSafe.Microsoft.RolePath)?.Value;
        
        if (role != TypeSafe.Roles.Admin)
        {
            context.Fail();
            return Task.CompletedTask;
        }
        
        var permissions = claims.FirstOrDefault(c => c.Type == TypeSafe.AuthorizationPayload.Permissions)?.Value;
        
        if (permissions is not null)
        {
            var dictPermission = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(permissions);

            if (dictPermission.TryGetValue(TypeSafe.Controller.PaymentType, out var permissionValue))
            {
                var listPermission = AuthorizeHelper.GetPermissionFromClaim(permissionValue).ToList();

                if (TypeSafe.Permissions.GetAdminPermissions().All(ap => listPermission.Contains(ap)))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
        }
        
        context.Fail();
        return Task.CompletedTask;
    }
}