using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.DTOs.IdentityDTOs;
using api.Helper;
using api.Models.Identity;
using api.Models.Identity.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace api.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationIdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _httpContext;

    public AuthenticationService(
        UserManager<ApplicationIdentityUser> userManager, 
        RoleManager<IdentityRole> roleManager, 
        IHttpContextAccessor httpContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _httpContext = httpContext;
    }
    
    
    public Task<bool> AddUserClaim(string user, Claim claim)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GenerateTokenString(string userEmail, JwtConfiguration jwtConfig)
    {
        var claims = await GetClaims(userEmail);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));

        var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer =  jwtConfig.Issuer,
            Audience = jwtConfig.Audience,
            Expires = DateTime.Now.AddMinutes(jwtConfig.ExpiresMin),
            SigningCredentials = signingCred
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(securityTokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    private async Task<List<Claim>> GetClaims(string userEmail)
    {
        var user = await _userManager.FindByEmailAsync(userEmail); 

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, userEmail),
        };

        claims.AddRange(GetClaimsSeperated(await _userManager.GetClaimsAsync(user)));
        var roles = await _userManager.GetRolesAsync(user);
        
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        
            // var identityRole = await _roleManager.FindByNameAsync(role);
            // claims.AddRange(GetClaimsSeperated(await _roleManager.GetClaimsAsync(identityRole)));
        }

        return claims;
    }
    
    private List<Claim> GetClaimsSeperated(IList<Claim> claims)
    {
        var result = new List<Claim>();
        foreach (var claim in claims)
        {
            result.AddRange(claim.DeserializePermissions().Select(t => new Claim(claim.Type, t.ToString())));
        }
        return result;
    }

    public async Task<bool> Login(UserLogin credentials)
    {
        var user = await _userManager.FindByEmailAsync(credentials.UserEmail);

        if (user is not null)   
            return await _userManager.CheckPasswordAsync(user, credentials.Password);

        return false;
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterUser(UserRegister user)
    {
        var identityUser = new ApplicationIdentityUser()
        {
            Email = user.UserEmail,
            PhoneNumber = user.UserPhone,
            UserName = user.UserName,
        };
        
        var result = await _userManager.CreateAsync(identityUser, user.Password);
        return result.Succeeded;
    }
}