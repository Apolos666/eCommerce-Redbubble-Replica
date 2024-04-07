using api.Data;
using api.DTOs.Order_DTOs.OrderStatusDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Order_Repositories.OrderStatus;

public class OrderStatusRepository : IOrderStatusRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public OrderStatusRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetOrderStatus>> GetOrderStatuses()
    {
        var orderStatuses = await _context.OrderStatus.ToListAsync();
        return _mapper.Map<List<GetOrderStatus>>(orderStatuses);
    }

    public async Task<GetOrderStatus> GetOrderStatus(int id)
    {
        var orderStatus = await _context.OrderStatus.FirstOrDefaultAsync(x => x.Id == id);
        
        if (orderStatus is null)
            return null;
        
        return _mapper.Map<GetOrderStatus>(orderStatus);
    }

    public async Task<(Models.OrderStatus, GetOrderStatus)> AddOrderStatus(AddOrderStatus addOrderStatus)
    {
        var orderStatus = _mapper.Map<Models.OrderStatus>(addOrderStatus);
        var savedOrderStatus = await _context.OrderStatus.AddAsync(orderStatus);
        await _context.SaveChangesAsync();
        return (savedOrderStatus.Entity, _mapper.Map<GetOrderStatus>(savedOrderStatus.Entity));
    }
}