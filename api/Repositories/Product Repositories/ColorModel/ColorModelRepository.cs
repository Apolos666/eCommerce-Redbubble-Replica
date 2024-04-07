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
        var colorHexCodeWithoutHash = ColorHexCode.TrimStart('#').ToLower();
        var colorModel = await GetColorModelBasedOnColorHex(colorHexCodeWithoutHash);
        
        if (colorModel is null)
            return null;
        
        var getColorModel = _mapper.Map<GetColorModel>(colorModel);
        
        return getColorModel;
    }

    private async Task<Models.ColorModel?> GetColorModelBasedOnColorHex(string colorHexCodeWithoutHash)
    {
        var colorModel = await _context.ColorModels
            .FromSqlInterpolated($"SELECT * FROM Colors WHERE LOWER(REPLACE(ColorHexCode, '#', '')) = {colorHexCodeWithoutHash}")
            .FirstOrDefaultAsync();
        return colorModel;
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

    public async Task<GetColorModel> UpdateColorNameBasedOnColorHex(string colorHex, UpdateColorModelName updateColorModelName)
    {
        var colorModel = await GetColorModelBasedOnColorHex(colorHex);
        
        if (colorModel is null)
            return null;
        
        _mapper.Map(updateColorModelName, colorModel);

        _context.ColorModels.Update(colorModel);
        await _context.SaveChangesAsync();
        
        var getUpdatedColorModel = _mapper.Map<GetColorModel>(colorModel);
        return getUpdatedColorModel;
    }

    public async Task<GetColorModel> UpdateColorHexBasedOnColorName(string colorName, UpdateColorModelHex updateColorModelHex)
    {
        var colorModel = await _context.ColorModels.FirstOrDefaultAsync(c => c.ColorName.ToLower() == colorName.ToLower());
        
        if (colorModel is null)
            return null;
        
        _mapper.Map(updateColorModelHex, colorModel);

        _context.ColorModels.Update(colorModel);
        await _context.SaveChangesAsync();
        
        var getUpdatedColorModel = _mapper.Map<GetColorModel>(colorModel);
        return getUpdatedColorModel;
    }
}