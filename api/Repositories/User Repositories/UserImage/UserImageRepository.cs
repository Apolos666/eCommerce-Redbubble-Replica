using api.Data;
using api.DTOs.User_DTOs.UserImageDTOs;
using AutoMapper;

namespace api.Repositories.User_Repositories.UserImage;

public class UserImageRepository : IUserImageRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserImageRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<GetUserImage> AddUserImage(AddUserImage addUserImage)
    {
        var userImage = _mapper.Map<Models.Identity.UserImage>(addUserImage);

        var result = await _context.UserImages.AddAsync(userImage);
        await _context.SaveChangesAsync();
        
        return _mapper.Map<GetUserImage>(result.Entity);
    }
}