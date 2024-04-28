using System.Security.Cryptography;
using api.DTOs.IdentityDTOs;
using api.Models.Identity;
using api.Models.Identity.Authentication;
using api.Models.Security;
using api.Models.TypeSafe;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.AuthenticationControllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationController(
        IAuthenticationService authenticationService,
        JwtConfiguration jwtConfiguration,
        IHttpContextAccessor httpContextAccessor)
    {
        _authenticationService = authenticationService;
        _jwtConfiguration = jwtConfiguration;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLogin credentials)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authenticationService.Login(credentials);
        if (!result.IsSuccess)
            return Unauthorized("Invalid credentials.");

        await GenerateAndWriteTokens(result.User);

        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegister user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authenticationService.RegisterUser(user);
        if (!result.IsSuccess)
            return BadRequest("Could not register user.");

        await GenerateAndWriteTokens(result.User);

        return Ok();
    }

    [HttpGet("refreshtoken")]
    public async Task<ActionResult<string>> RefreshToken()
    {
        var refreshToken = _httpContextAccessor.HttpContext?.Request.Cookies[TypeSafe.CookiesName.RefreshToken];

        var user = await _authenticationService.GetUserByRefreshToken(refreshToken);
        if (user == null || user.ExpiresTime < DateTime.Now)
            return Unauthorized("Refresh Token has expired.");

        await GenerateAndWriteTokens(user);

        return Ok();
    }
    
    // Todo: Chi cho phep nguoi dung co goi den chinh cai cua ho thoi, khong the goi den cua nguoi khac
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<GetMe>> Me()
    {
        var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
        
        if (userName is null)
            return Unauthorized();
        
        var user = await _authenticationService.GetMe(userName);
        
        if (user is null)
            return NotFound("User not found.");
        
        return Ok(user);
    }

    private async Task GenerateAndWriteTokens(ApplicationIdentityUser user)
    {
        var accessToken = await _authenticationService.GenerateTokenString(user, _jwtConfiguration);
        _authenticationService.WriteAccessToken(accessToken);
        var generatedRefreshToken =  _authenticationService.GenerateRefreshToken();
        await _authenticationService.WriteRefreshToken(generatedRefreshToken, user);
    }
}