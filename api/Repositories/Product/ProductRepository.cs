using api.Data;
using api.DTOs.ProductDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Product;

public class ProductRepository : IProductRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<List<GetProduct>> GetAll()
    {
        var productQuery = _context.Products.AsQueryable();
        
        // Add more logic here
        
        var products = await productQuery.ToListAsync();
        var getProducts = _mapper.Map<List<GetProduct>>(products);
        return getProducts;
    }

    public async Task<GetProduct> GetProductById(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        
        if (product is null)
            return null;
        
        var getProduct = _mapper.Map<GetProduct>(product);
        return getProduct;
    }

    public async Task<(Models.Product, GetProduct)> AddProduct(AddProduct addProduct)
    {
        var product = _mapper.Map<Models.Product>(addProduct);
        var savedProduct = await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        var getProduct = _mapper.Map<GetProduct>(savedProduct.Entity);
        return (savedProduct.Entity, getProduct);
    }
}