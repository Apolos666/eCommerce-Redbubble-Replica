using api.Repositories.User_Repositories.UserImage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.UserControllers;

[ApiController]
[Route("api/[controller]s")]
[Authorize]
public class UserImageController : ControllerBase
{
    private readonly IUserImageRepository _userImageRepository;

    public UserImageController(IUserImageRepository userImageRepository)
    {
        _userImageRepository = userImageRepository;
    }
    
    [HttpGet]
    [Route("get-current-active-profile-image-url")]
    public async Task<IActionResult> GetCurrentActiveProfileImageUrl()
    {
        var userName = HttpContext.User.Identity?.Name;
        
        var result = await _userImageRepository.GetCurrentActiveProfileImageUrlAsync(userName);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("get-all-profile-images")]
    public async Task<IActionResult> GetAllProfileImages()
    {
        var userName = HttpContext.User.Identity?.Name;
        
        var result = await _userImageRepository.GetAllProfileImagesAsync(userName);

        return Ok(result);
    }
    
    [HttpPost]
    [Route("set-active-profile-image")]
    public async Task<ActionResult<bool>> SetActiveProfileImageAsync([FromQuery] string imageUrl)
    {
        var userName = HttpContext.User.Identity?.Name;
        
        var result = await _userImageRepository.SetActiveProfileImageAsync(userName, imageUrl);
        
        return Ok(result);
    }
}