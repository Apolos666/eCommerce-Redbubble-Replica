using System.Security.Claims;
using api.Models.TypeSafe;

namespace api.Helper;

public static class AuthorizationHelper
{
    public static Claim GetFullAccessClaims(string controllerName)
    {
        return new Claim(controllerName,
            ClaimHelper.SerializePermissions(
                TypeSafe.Permissions.Read,
                TypeSafe.Permissions.Write,
                TypeSafe.Permissions.Update,
                TypeSafe.Permissions.Patch,
                TypeSafe.Permissions.Delete
            ));
    }
    
    public static Claim GetcontributorClaims(string controllerName)
    {
        return new Claim(controllerName,
            ClaimHelper.SerializePermissions(
                TypeSafe.Permissions.Read,
                TypeSafe.Permissions.Write
            ));
    }
    
    public static Claim GetReadClaims(string controllerName)
    {
        return new Claim(controllerName,
            ClaimHelper.SerializePermissions(
                TypeSafe.Permissions.Read
            ));
    }
}