using api.Data;
using api.DTOs.ProductCategoryDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.ProductCategory;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductCategoryRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<List<GetProductCategory>> GetAll()
    {
        var productCategoryQuery = _context.ProductCategories.AsQueryable();
        
        // Add more logic here
        
        var productCategories = await productCategoryQuery.ToListAsync();
        var getProductCategories = _mapper.Map<List<GetProductCategory>>(productCategories);

        return getProductCategories;
    }
}