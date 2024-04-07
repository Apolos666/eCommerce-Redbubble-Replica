using api.Data;
using api.DTOs.ProductImage;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.ProductImage;

public class ProductImageRepository : IProductImageRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductImageRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<List<GetProductImage>> GetAllProductImages()
    {
        var productImagesQuery = _context.ProductImages.AsQueryable();
        
        // Add more logic here
        
        var productImages = await productImagesQuery.ToListAsync();
        var getProductImages = _mapper.Map<List<GetProductImage>>(productImages);
        return getProductImages;
    }

    public async Task<GetProductImage> GetProductImageById(int id)
    {
        var productImage = await _context.ProductImages.FirstOrDefaultAsync(pi => pi.Id == id);
        
        if (productImage is null)
            return null;
        
        var getProductImage = _mapper.Map<GetProductImage>(productImage);
        return getProductImage;
    }

    public async Task<(Models.ProductImage, GetProductImage)> AddProductImage(AddProductImage addProductImage)
    {
        var productImage = _mapper.Map<Models.ProductImage>(addProductImage);
        var savedProductImage = await _context.ProductImages.AddAsync(productImage);
        await _context.SaveChangesAsync();
        var getProductImage = _mapper.Map<GetProductImage>(savedProductImage.Entity);
        return (savedProductImage.Entity, getProductImage);
    }
}