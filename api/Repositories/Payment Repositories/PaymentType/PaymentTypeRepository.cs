using api.Data;
using api.DTOs.PaymentTypeDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.PaymentType;

public class PaymentTypeRepository : IPaymentTypeRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PaymentTypeRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<Models.PaymentType>> GetAllPaymentTypes()
    {
        var paymentTypes = await _context.PaymentTypes.ToListAsync();
        return paymentTypes;
    }

    public async Task<Models.PaymentType> GetPaymentTypeById(int id)
    {
        var paymentType = await _context.PaymentTypes.FirstOrDefaultAsync(p => p.Id == id);
        
        if (paymentType is null)
            return null;
        
        return paymentType;
    }

    public async Task<Models.PaymentType> AddPaymentType(AddPaymentType addPaymentType)
    {
        var paymentType = _mapper.Map<Models.PaymentType>(addPaymentType);
        
        var savedPaymentType = await _context.PaymentTypes.AddAsync(paymentType);
        await _context.SaveChangesAsync();
        
        return savedPaymentType.Entity;
    }
}