using api.Data;
using api.DTOs.AttributeTypeModelDTOs;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.AttributeTypeModel;

public class ProductAttributeTypeRepository : IProductAttributeTypeRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductAttributeTypeRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetProductAttributeType>> GetAll()
    {
        var attributeTypeQuery = _context.ProductAttributeTypes.AsQueryable();

        // Add Logics here

        var attributeTypes = await attributeTypeQuery.ToListAsync();
        var getAttributeTypes = _mapper.Map<List<GetProductAttributeType>>(attributeTypes);
        return getAttributeTypes;
    }

    public async Task<ProductAttributeType> Add(AddProductAttributeType addProductAttributeType)
    {
        var attributeType = _mapper.Map<ProductAttributeType>(addProductAttributeType);

        var savedAttributeType = await _context.ProductAttributeTypes.AddAsync(attributeType);

        await _context.SaveChangesAsync();
        return savedAttributeType.Entity;
    }

    public async Task<GetProductAttributeType> GetById(int id)
    {
        var attributeType = await _context.ProductAttributeTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (attributeType is null)
            throw new Exception("Product attribute type not found");

        var getAttributeType = _mapper.Map<GetProductAttributeType>(attributeType);

        return getAttributeType;
    }

    public async Task<GetProductAttributeType> Update(int id, UpdateProductAttributeType addProductAttributeType)
    {
        var attributeType = await _context.ProductAttributeTypes.FirstOrDefaultAsync(x => x.Id == id);

        var attributeTypeUpdated = _mapper.Map(addProductAttributeType, attributeType);
        _context.ProductAttributeTypes.Update(attributeTypeUpdated);
        await _context.SaveChangesAsync();

        var getAttributeType = _mapper.Map<GetProductAttributeType>(attributeTypeUpdated);
        return getAttributeType;
    }
}