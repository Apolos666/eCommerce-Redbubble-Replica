using System.Security.Claims;
using api.Extensions;

namespace api.Helper;

public static class ClaimHelper
{
    public static string SerializePermissions(params int[] permissions)
    {
        return permissions.Serialize();
    }

    public static List<int> DeserializePermissions(this Claim claim)
    {
        return claim.Value.Deserialize<List<int>>();
    }
}