using System.Security.Claims;
using api.DTOs.IdentityDTOs;
using api.Models.Identity.Authentication;

namespace api.Services;

public interface IAuthenticationService
{
    Task<bool> AddUserClaim(string user, Claim claim);
    Task<string> GenerateTokenString(string userEmail, JwtConfiguration jwtConfig);
    Task<bool> Login(UserLogin credentials);
    Task Logout();
    Task<bool> RegisterUser(UserRegister user);
}