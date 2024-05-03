namespace api.Models.Identity.Authentication;

public class JwtConfiguration
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiresMin { get; set; }
}