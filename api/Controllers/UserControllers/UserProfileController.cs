using api.DTOs.User_DTOs.UserImageDTOs;
using api.Services.AzureServices.BlobStrorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.UserControllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileBlobServices _userProfileBlobServices;

    public UserProfileController(IUserProfileBlobServices userProfileBlobServices)
    {
        _userProfileBlobServices = userProfileBlobServices;
    }
    
    [HttpPost]
    [Route("upload-profile-image")]
    public async Task<IActionResult> UploadProfileImageAsync([FromForm] IFormFile file)
    {
        // Tạo một đương dẫn tạm thời để lưu file
        var tempPath = Path.GetTempFileName();
        
        // Copy file vào đường dẫn tạm thời
        await using (var stream = new FileStream(tempPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Lấy username của user authenticate hiện tại
        var userName = HttpContext.User.Identity?.Name;
        
        var result = await _userProfileBlobServices.UploadProfileImageAsync(userName, tempPath, file.FileName);
        
        System.IO.File.Delete(tempPath);
        
        return Ok(result);
    }
}