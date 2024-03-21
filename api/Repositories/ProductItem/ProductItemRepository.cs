using api.Data;
using api.DTOs.ProductItemDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.ProductItem;

public class ProductItemRepository : IProductItemRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductItemRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<List<GetProductItem>> GetAll()
    {
        var productItemQuery = _context.ProductItems.AsQueryable();
        
        // Add more logic here
        
        var productItems = await productItemQuery.ToListAsync();
        var getProductItems = _mapper.Map<List<GetProductItem>>(productItems);
        return getProductItems;
    }

    public async Task<GetProductItem> GetProductItemById(int id)
    {
        var productItem = await _context.ProductItems.FirstOrDefaultAsync(p => p.Id == id);
        
        if (productItem is null)
            return null;
        
        var getProductItem = _mapper.Map<GetProductItem>(productItem);
        return getProductItem;
    }

    public async Task<(Models.ProductItem, GetProductItem)> AddProductItem(AddProductItem addProductItem)
    {
        
        // Check if the ColorId exists in the Colors table
        var colorExists = await _context.ColorModels.AnyAsync(c => c.Id == addProductItem.ColorId);
        if (!colorExists)
        {
            Console.WriteLine("Color does not exist");
        }

        // Check if the ProductId exists in the Products table
        var productExists = await _context.Products.AnyAsync(p => p.ProductCategoryId == addProductItem.ProductId);
        if (!productExists)
        {
            Console.WriteLine("Product does not exist");
        }
        
        var productItem = _mapper.Map<Models.ProductItem>(addProductItem);
        var savedProductItem = await _context.ProductItems.AddAsync(productItem);
        await _context.SaveChangesAsync();
        var getProductItem = _mapper.Map<GetProductItem>(savedProductItem.Entity);
        return (savedProductItem.Entity, getProductItem);
    }
}