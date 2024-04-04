using api.DTOs.IdentityDTOs;
using api.Models.Identity.Authentication;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.AuthenticationControllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly JwtConfiguration _jwtConfiguration;

    public AuthenticationController(
        IAuthenticationService authenticationService, 
        JwtConfiguration jwtConfiguration)
    {
        _authenticationService = authenticationService;
        _jwtConfiguration = jwtConfiguration;
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
}