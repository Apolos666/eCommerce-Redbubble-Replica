using api.Data;
using api.DTOs.ProductAttributeDTOs;
using api.Extensions;
using api.Models;
using api.Utilities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.ProductAttributeModel;

public class ProductAttributeRepository : IProductAttributeRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductAttributeRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<PagedResult<GetProductAttribute>> GetAll(QueryStringParameters productAttributeParameters)
    {
        var productAttributes = _context.ProductAttributes
            .AsQueryable()
            .Include(pa => pa.Product)
            .Include(pa => pa.ProductAttributeOption);
        
        var getProductAttributesPagedResults = await productAttributes
            .CreatePagedResultsAsync<ProductAttribute, GetProductAttribute>(
                _mapper.ConfigurationProvider, productAttributeParameters.PageNumber,
                productAttributeParameters.PageSize);

        return getProductAttributesPagedResults;
    }

    public async Task<List<GetProductAttribute>> GetAllByProductId(int productId)
    {
        var productAttributes = _context.ProductAttributes
            .Include(pa => pa.Product)
            .Include(pa => pa.ProductAttributeOption)
            .Where(pa => pa.ProductId == productId);
        
        var productAttributesList = await productAttributes.ToListAsync();
        var getProductAttributes = _mapper.Map<List<GetProductAttribute>>(productAttributesList);
        
        return getProductAttributes;
    }

    public async Task<List<GetProductAttribute>> GetAllByAttributeOptionId(int attributeOptionId)
    {
        var productAttributes = _context.ProductAttributes
            .Include(pa => pa.Product)
            .Include(pa => pa.ProductAttributeOption)
            .Where(pa => pa.ProductAttributeOptionId == attributeOptionId);
        
        var productAttributesList = await productAttributes.ToListAsync();
        var getProductAttributes = _mapper.Map<List<GetProductAttribute>>(productAttributesList);
        
        return getProductAttributes;
    }

    public async Task<GetProductAttribute> GetById(int id)
    {
        var productAttribute = await _context.ProductAttributes
            .Include(pa => pa.Product)
            .Include(pa => pa.ProductAttributeOption)
            .FirstOrDefaultAsync(pa => pa.Id == id);
        
        if (productAttribute is null)
            return null;
        
        var getProductAttribute = _mapper.Map<GetProductAttribute>(productAttribute);
        return getProductAttribute;
    }

    public async Task<(ProductAttribute, GetProductAttribute)> Create(AddProductAttribute addProductAttribute)
    {
        var productAttribute = _mapper.Map<ProductAttribute>(addProductAttribute);
        await _context.ProductAttributes.AddAsync(productAttribute);
        await _context.SaveChangesAsync();
        var getProductAttribute = _mapper.Map<GetProductAttribute>(productAttribute);
        return (productAttribute, getProductAttribute);
    }
}