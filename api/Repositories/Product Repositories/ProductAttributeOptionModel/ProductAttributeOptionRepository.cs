using api.Data;
using api.DTOs.AttributeTypeModelDTOs;
using api.DTOs.ProductAttributeOptionDTOs;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.ProductAttributeOptionModel;

public class ProductAttributeOptionRepository : IProductAttributeOptionRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductAttributeOptionRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<List<GetProductAttributeOption>> GetAll()
    {
        var productAttributeOptions = await _context.ProductAttributeOptions
            .Include(pao => pao.ProductAttributeType)
            .ToListAsync();
        
        var getProductAttributeOptions = _mapper.Map<List<GetProductAttributeOption>>(productAttributeOptions);
        
        return getProductAttributeOptions;
    }

    public async Task<GetProductAttributeOption> GetProductAttributeOptionById(int id)
    {
        var productAttributeOption = await _context.ProductAttributeOptions
            .Include(pao => pao.ProductAttributeType)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (productAttributeOption is null)
            return null;
        
        var getProductAttributeOption = _mapper.Map<GetProductAttributeOption>(productAttributeOption);
        
        return getProductAttributeOption;
    }

    public async Task<(ProductAttributeOption, GetProductAttributeOption)> AddProductAttributeOption(AddProductAttributeOption addProductAttributeOption)
    {
        var productAttributeOption = _mapper.Map<ProductAttributeOption>(addProductAttributeOption);
        var savedProductAttributeOption = await _context.ProductAttributeOptions.AddAsync(productAttributeOption);
        await _context.SaveChangesAsync();
        var getProductAttributeOption = _mapper.Map<GetProductAttributeOption>(savedProductAttributeOption.Entity);
        return (savedProductAttributeOption.Entity, getProductAttributeOption);
    }
}