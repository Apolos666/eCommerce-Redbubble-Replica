﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.DTOs.IdentityDTOs;
using api.Helper;
using api.Models.Identity;
using api.Models.Identity.Authentication;
using api.Models.TypeSafe;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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

    public async Task<bool> AddUserRole(ApplicationIdentityUser user, string role)
    {
        var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
            
        return addToRoleResult.Succeeded;
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
            new Claim(ClaimTypes.Name, user.UserName),
        };
        
        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var permissions = new Dictionary<string, List<string>>();
        var userClaims = await _userManager.GetClaimsAsync(user);
        foreach (var claim in userClaims)
        {
            permissions[claim.Type] = claim.DeserializePermissions().Select(p => p.ToString()).ToList();
        }
        claims.Add(new Claim("Permissions", JsonConvert.SerializeObject(permissions)));
        
        // claims.AddRange(GetClaimsSeperated(await _userManager.GetClaimsAsync(user)));
        
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
            UserName = user.UserName,
        };
        
        var result = await _userManager.CreateAsync(identityUser, user.Password);

        if (result.Succeeded)
        {
            return await AddUserRole(identityUser, TypeSafe.Roles.User);
        }
        
        return result.Succeeded;
    }
}