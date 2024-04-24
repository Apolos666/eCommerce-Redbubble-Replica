using System.Security.Claims;
using api.DTOs.IdentityDTOs;
using api.Models.Identity;
using api.Models.Identity.Authentication;
using api.Models.Security;

namespace api.Services;

public interface IAuthenticationService
{
    Task<bool> AddUserClaim(string user, Claim claim);
    Task<bool> AddUserRole(ApplicationIdentityUser user, string role);
    Task<string> GenerateTokenString(ApplicationIdentityUser user, JwtConfiguration jwtConfig);
    void WriteAccessToken(string accessToken);
    RefreshToken GenerateRefreshToken();
    Task WriteRefreshToken(RefreshToken refreshToken, ApplicationIdentityUser? user);
    Task<ApplicationIdentityUser?> GetUserByRefreshToken(string refreshToken);
    Task<(bool IsSuccess, ApplicationIdentityUser? User)> Login(UserLogin credentials);
    Task Logout();
    Task<(bool IsSuccess, ApplicationIdentityUser? User)> RegisterUser(UserRegister user);
    
    
}