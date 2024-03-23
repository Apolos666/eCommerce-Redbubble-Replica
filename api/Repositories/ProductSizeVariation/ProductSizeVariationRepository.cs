using api.Data;
using api.DTOs.ProductSizeVariationDTOs;
using api.Extensions;
using api.Models;
using api.Utilities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.ProductSizeVariation;

public class ProductSizeVariationRepository : IProductSizeVariationRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductSizeVariationRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<PagedResult<GetProductSizeVariation>> GetAll(QueryStringParameters productSizeVariationParameters)
    {
        var productSizeVariationQuery = _context.ProductSizeVariations
            .AsQueryable()
            .Include(c => c.ProductItem)
            .Include(c => c.SizeOption);

        var getProductSizeVariationPagedResults = productSizeVariationQuery
            .CreatePagedResultsAsync<Models.ProductSizeVariation, GetProductSizeVariation>(
                _mapper.ConfigurationProvider, productSizeVariationParameters.PageNumber,
                productSizeVariationParameters.PageSize);

        return getProductSizeVariationPagedResults;
    }

    public async Task<List<GetProductSizeVariation>> GetAllByProductItemId(int productItemId)
    {
        var productSizeVariationQuery = _context.ProductSizeVariations
            .AsQueryable()
            .Include(c => c.ProductItem)
            .Include(c => c.SizeOption)
            .Where(c => c.ProductItemId == productItemId);
        
        var ProductSizeVariations = await productSizeVariationQuery.ToListAsync();
        var getProductSizeVariations = _mapper.Map<List<GetProductSizeVariation>>(ProductSizeVariations);
        return getProductSizeVariations;
    }

    public async Task<List<GetProductSizeVariation>> GetAllBySizeOptionsId(int sizeOptionsId)
    {
        var productSizeVariationQuery = _context.ProductSizeVariations
            .AsQueryable()
            .Include(c => c.ProductItem)
            .Include(c => c.SizeOption)
            .Where(c => c.SizeOptionsId == sizeOptionsId);
        
        var ProductSizeVariations = await productSizeVariationQuery.ToListAsync();
        var getProductSizeVariations = _mapper.Map<List<GetProductSizeVariation>>(ProductSizeVariations);
        return getProductSizeVariations;
    }

    public async Task<GetProductSizeVariation> GetById(int id)
    {
        var productSizeVariation = await _context.ProductSizeVariations
            .Include(c => c.ProductItem)
            .Include(c => c.SizeOption)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (productSizeVariation is null)
            return null;
        
        var getProductSizeVariation = _mapper.Map<GetProductSizeVariation>(productSizeVariation);
        return getProductSizeVariation;
    }

    public async Task<(Models.ProductSizeVariation, GetProductSizeVariation)> Create(
        AddProductSizeVariation addProductSizeVariation)
    {
        var productSizeVariation = _mapper.Map<Models.ProductSizeVariation>(addProductSizeVariation);
        var savedProductSizeVariation = await _context.ProductSizeVariations.AddAsync(productSizeVariation);
        await _context.SaveChangesAsync();
        var getProductSizeVariation = _mapper.Map<GetProductSizeVariation>(savedProductSizeVariation.Entity);
        return (savedProductSizeVariation.Entity, getProductSizeVariation);
    }
}