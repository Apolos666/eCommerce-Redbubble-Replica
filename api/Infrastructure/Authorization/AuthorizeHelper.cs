using System.Security.Claims;

namespace api.Infrastructure.Authorization;

public class AuthorizeHelper
{
    public static IEnumerable<int> GetPermissionFromClaim(List<string> claimsPermission)
    {
        return claimsPermission.Select(int.Parse).ToList();
    }
}