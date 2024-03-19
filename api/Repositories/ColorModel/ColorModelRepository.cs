using api.Data;
using api.DTOs.ColorModelDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.ColorModel;

public class ColorModelRepository : IColorModelRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ColorModelRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<List<GetColorModel>> GetAll()
    {
        var colorModelQuery = _context.ColorModels.AsQueryable();
        
        // Add more logic here
        
        var colorModels = await colorModelQuery.ToListAsync();
        var getColorModels = _mapper.Map<List<GetColorModel>>(colorModels);
        return getColorModels;
    }

    public async Task<GetColorModel> GetColorByName(string colorName)
    {
        var colorModel = await _context.ColorModels.FirstOrDefaultAsync(c => c.ColorName.ToLower() == colorName.ToLower());
        
        if (colorModel is null)
            return null;
        
        var getColorModel = _mapper.Map<GetColorModel>(colorModel);
        
        return getColorModel;
    }

    public async Task<GetColorModel> GetColorByColorHex(string ColorHexCode)
    {
        var colorModel = _context.ColorModels.
            FirstOrDefaultAsync(c => c.ColorHexCode.TrimStart('#').ToLower().Equals(ColorHexCode.TrimStart('#').ToLower()));
        
        if (colorModel is null)
            return null;
        
        var getColorModel = _mapper.Map<GetColorModel>(colorModel);
        
        return getColorModel;
    }

    public async Task<GetColorModel> Add(AddColorModel addColorModel)
    {
        try
        {
            var colorModel = _mapper.Map<Models.ColorModel>(addColorModel);
        
            var entityEntry = await _context.ColorModels.AddAsync(colorModel);
            await _context.SaveChangesAsync();

            var savedColorModel = entityEntry.Entity;
            var getSavedColorModel = _mapper.Map<GetColorModel>(savedColorModel);
            return getSavedColorModel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<GetColorModel> Update(UpdateColorModel updateColorModel)
    {
        throw new NotImplementedException();
    }
}