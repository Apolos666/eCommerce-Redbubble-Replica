using api.Data;
using api.DTOs.SizeCategoryDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.SizeCategory;

public class SizeCategoryRepository : ISizeCategoryRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public SizeCategoryRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<List<GetSizeCategory>> GetAll()
    {
        var sizeCategories = await _context.SizeCategories
            .Include(sc => sc.ProductCategories)
            .ToListAsync();
        
        var getSizeCategories = _mapper.Map<List<GetSizeCategory>>(sizeCategories);
        
        return getSizeCategories;
    }

    public async Task<GetSizeCategory> GetSizeCategoryById(int id)
    {
        var sizeCategory = await _context.SizeCategories
            .Include(sc => sc.ProductCategories)
            .FirstOrDefaultAsync(sc => sc.Id == id);

        if (sizeCategory is null)
            return null;
        
        var getSizeCategory = _mapper.Map<GetSizeCategory>(sizeCategory);
        return getSizeCategory;
    }

    public async Task<(Models.SizeCategory, GetSizeCategory)> AddSizeCategory(AddSizeCategory addSizeCategory)
    {
        var sizeCategory = _mapper.Map<Models.SizeCategory>(addSizeCategory);
        
        var savedSizeCategory = await _context.SizeCategories.AddAsync(sizeCategory);
        await _context.SaveChangesAsync();
        
        var getSizeCategory = _mapper.Map<GetSizeCategory>(savedSizeCategory.Entity);
        return (savedSizeCategory.Entity, getSizeCategory);
    }
}