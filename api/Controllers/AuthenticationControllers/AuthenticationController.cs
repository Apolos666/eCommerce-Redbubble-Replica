using api.DTOs.IdentityDTOs;
using api.Models.Identity.Authentication;
using api.Models.TypeSafe;
using api.Services;
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
        if (result)
        {
            var token = await _authenticationService.GenerateTokenString(credentials.UserEmail, _jwtConfiguration);
            return Ok(new TokenReponse() { Token = token });
        }

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegister user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authenticationService.RegisterUser(user);
        if (result)
        {
            var token = await _authenticationService.GenerateTokenString(user.UserEmail, _jwtConfiguration);
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(TypeSafe.CookiesName.Token, token,
                new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTime.Now.AddDays(123),
                    Secure = false,
                    SameSite = SameSiteMode.None,
                    Domain = "http://localhost:5173"
                });

            return Ok();
        }

        return BadRequest("Could not register user.");
    }
}