using api.Data;
using api.DTOs.ProductCategoryDTOs;
using api.Extensions;
using api.Models;
using api.Utilities;
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
    
    public async Task<PagedResult<GetProductCategory>> GetAll(ProductCategoryParameters queryParameters)
    {
        var productCategoryQuery = _context.ProductCategories.AsQueryable();
        
        var getProductCategoryPagedResults = await productCategoryQuery
            .CreatePagedResultsAsync<Models.ProductCategory, GetProductCategory>(_mapper.ConfigurationProvider, queryParameters.PageNumber, queryParameters.PageSize);

        return getProductCategoryPagedResults;
    }

    public async Task<GetProductCategory> GetProductCategoryById(int id)
    {
        var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(pc => pc.ProductCategoryId == id);
        
        if (productCategory is null)
            return null;
        
        var getProductCategory = _mapper.Map<GetProductCategory>(productCategory);
        return getProductCategory;
    }

    public async Task<(Models.ProductCategory, GetProductCategory)> AddProductCategory(AddProductCategory addProductCategory)
    {
        var productCategory = _mapper.Map<Models.ProductCategory>(addProductCategory);
        var savedProductCategory = await _context.ProductCategories.AddAsync(productCategory);
        await _context.SaveChangesAsync();
        var getProductCategory = _mapper.Map<GetProductCategory>(savedProductCategory.Entity);
        return (savedProductCategory.Entity, getProductCategory);
    }
}