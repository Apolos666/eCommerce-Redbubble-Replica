using api.Data;
using api.DTOs.User_DTOs.UserImageDTOs;
using api.Models.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.User_Repositories.UserImage;

public class UserImageRepository : IUserImageRepository
{
    private readonly UserManager<ApplicationIdentityUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserImageRepository(UserManager<ApplicationIdentityUser> userManager, ApplicationDbContext context,
        IMapper mapper)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetUserImage> AddUserImageAsync(AddUserImage addUserImage)
    {
        var userImage = _mapper.Map<Models.Identity.UserImage>(addUserImage);

        var result = await _context.UserImages.AddAsync(userImage);
        await _context.SaveChangesAsync();

        return _mapper.Map<GetUserImage>(result.Entity);
    }

    public async Task<List<string>> GetAllProfileImagesAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        var userImages = await _context.UserImages.Where(ui => ui.UserId == user.Id).ToListAsync();
        
        return userImages.Select(ui => ui.ImageUrl).ToList();
    }

    public async Task<string> GetCurrentActiveProfileImageUrlAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        var userImage = await _context.UserImages.FirstOrDefaultAsync(ui => ui.UserId == user.Id && ui.IsProfileImage);

        return userImage.ImageUrl;
    }

    public async Task<bool> DeactiveAllProfileImagesAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return false;
        }

        var userImage = await _context.UserImages.Where(ui => ui.UserId == userId).ToListAsync();

        userImage.ForEach(ui => ui.IsProfileImage = false);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> SetActiveProfileImageAsync(string userName, string imageUrl)
    {
        var user = await _userManager.FindByNameAsync(userName);
        
        var userImage = await _context.UserImages.FirstOrDefaultAsync(ui => ui.UserId == user.Id && ui.ImageUrl == imageUrl);
        
        if (userImage is null)
            return false;

        await DeactiveAllProfileImagesAsync(user.Id);
        
        userImage.IsProfileImage = true;

        await _context.SaveChangesAsync();

        return true;
    }
}