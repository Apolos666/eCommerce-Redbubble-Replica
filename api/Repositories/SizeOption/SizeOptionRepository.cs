using api.Data;
using api.DTOs.SizeCategoryDTOs;
using api.DTOs.SizeOptionDTOs;
using api.Repositories.SizeCategory;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.SizeOption;

public class SizeOptionRepository : ISizeOptionRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public SizeOptionRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<List<GetSizeOption>> GetAll()
    {
        var sizeOptions = await _context.SizeOptions
            .Include(so => so.SizeCategory)
            .ToListAsync();
        
        var getSizeOptions = _mapper.Map<List<GetSizeOption>>(sizeOptions);
        
        return getSizeOptions;
    }

    public async Task<GetSizeOption> GetSizeOptionById(int id)
    {
        var sizeOption = await _context.SizeOptions
            .Include(so => so.SizeCategory)
            .FirstOrDefaultAsync(so => so.Id == id);

        if (sizeOption is null)
            return null;
        
        var getSizeOption = _mapper.Map<GetSizeOption>(sizeOption);
        
        return getSizeOption;
    }

    public async Task<(Models.SizeOption, GetSizeOption)> AddSizeOption(AddSizeOption addSizeOption)
    {
        var sizeOption = _mapper.Map<Models.SizeOption>(addSizeOption);
        var savedSizeOption = await _context.SizeOptions.AddAsync(sizeOption);
        await _context.SaveChangesAsync();
        var getSizeOption = _mapper.Map<GetSizeOption>(savedSizeOption.Entity);
        return (savedSizeOption.Entity, getSizeOption);
    }
}