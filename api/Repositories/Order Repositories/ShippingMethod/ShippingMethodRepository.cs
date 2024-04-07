using api.Data;
using api.DTOs.ShippingMethodDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.ShippingMethod;

public class ShippingMethodReopository : IShippingMethodRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ShippingMethodReopository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetShippingMethod>> GetShippingMethods()
    {
        var shippingMethods = await _context.ShippingMethods.ToListAsync();
        return _mapper.Map<List<GetShippingMethod>>(shippingMethods);
    }

    public async Task<GetShippingMethod> GetShippingMethod(int id)
    {
        var shippingMethod = await _context.ShippingMethods.FirstOrDefaultAsync(x => x.Id == id);
        
        if (shippingMethod is null)
            return null;
        
        return _mapper.Map<GetShippingMethod>(shippingMethod);
    }

    public async Task<(Models.ShippingMethod, GetShippingMethod)> AddShippingMethod(AddShippingMethod addShippingMethod)
    {
        var shippingMethod = _mapper.Map<Models.ShippingMethod>(addShippingMethod);
        
        var savedShippingMethod = await _context.ShippingMethods.AddAsync(shippingMethod);
        await _context.SaveChangesAsync();
        
        return (savedShippingMethod.Entity, _mapper.Map<GetShippingMethod>(savedShippingMethod.Entity));
    }
}