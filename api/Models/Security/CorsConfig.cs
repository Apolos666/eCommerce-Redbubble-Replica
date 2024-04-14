namespace api.Models.Security;

public class CorsConfig(string policyName, string originUrl)
{
    public string PolicyName { get; set; } = policyName;
    public string OriginUrl { get; set; } = originUrl;
}