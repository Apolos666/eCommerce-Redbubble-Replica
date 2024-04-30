namespace api.DTOs.User_DTOs.UserImageDTOs;

public class UploadPhotoRequest
{
    public IFormFile File { get; set; }
    public string Name { get; set; }
    public string FileName { get; set; }
}