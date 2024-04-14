using api.Data;
using api.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace api.Services.ServicesRegistration;

public static class SeedingDataService
{
    public static async Task<IApplicationBuilder> SeedDataAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationIdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // // Delete all data in AspNetUserClaims, AspNetUsers, AspNetUserRoles
            // applicationDbContext.UserClaims.RemoveRange(applicationDbContext.UserClaims);
            // applicationDbContext.Users.RemoveRange(applicationDbContext.Users);
            // applicationDbContext.UserRoles.RemoveRange(applicationDbContext.UserRoles);
            // await applicationDbContext.SaveChangesAsync();
            //
            // // if (!userManager.Users.Any())
            // // {
            // // Creating User Entities
            // var adminUser = new ApplicationIdentityUser() { UserName = "admin", Email = "admin@test.com" };
            // var contributorUser = new ApplicationIdentityUser() { UserName = "cont", Email = "c@test.com" };
            // var user = new ApplicationIdentityUser() { UserName = "user", Email = "user@test.com" };
            //
            // // Creating Role Entities
            // var adminRole = new IdentityRole(TypeSafe.Roles.Admin);
            // var contributorRole = new IdentityRole(TypeSafe.Roles.Contributor);
            // var userRole = new IdentityRole(TypeSafe.Roles.User);
            //
            // // Adding Roles
            // await roleManager.CreateAsync(adminRole);
            // await roleManager.CreateAsync(contributorRole);
            // await roleManager.CreateAsync(userRole);
            //
            // // Adding Users with Password
            // await userManager.CreateAsync(adminUser, "123456");
            // await userManager.CreateAsync(contributorUser, "123456");
            // await userManager.CreateAsync(user, "123456");
            //
            // // Ading Claims to Users
            // // Ading Claims to Users
            // await userManager.AddClaimAsync(adminUser,
            //     AuthorizationHelper.GetFullAccessClaims(TypeSafe.Controller.PaymentType));
            // await userManager.AddClaimAsync(adminUser,
            //     AuthorizationHelper.GetFullAccessClaims(TypeSafe.Controller.ShippingMethod));
            // await userManager.AddClaimAsync(adminUser,
            //     AuthorizationHelper.GetFullAccessClaims(TypeSafe.Controller.OrderStatus));
            // await userManager.AddClaimAsync(adminUser,
            //     AuthorizationHelper.GetFullAccessClaims(TypeSafe.Controller.UserPaymentMethod));
            // await userManager.AddClaimAsync(contributorUser,
            //     AuthorizationHelper.GetcontributorClaims(TypeSafe.Controller.Product));
            // await userManager.AddClaimAsync(user, AuthorizationHelper.GetReadClaims(TypeSafe.Controller.Product));
            // await userManager.AddClaimAsync(user, AuthorizationHelper.GetFullAccessClaims(TypeSafe.Controller.UserPaymentMethod));
            //
            // // Adding Roles to Users
            // await userManager.AddToRoleAsync(adminUser, TypeSafe.Roles.Admin);
            // await userManager.AddToRoleAsync(contributorUser, TypeSafe.Roles.Contributor);
            // await userManager.AddToRoleAsync(user, TypeSafe.Roles.User);
            // // }
        }

        return app;
    }
}