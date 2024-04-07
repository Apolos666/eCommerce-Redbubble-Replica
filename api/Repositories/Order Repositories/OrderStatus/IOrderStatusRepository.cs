using api.DTOs.Order_DTOs.OrderStatusDTOs;

namespace api.Repositories.Order_Repositories.OrderStatus;

public interface IOrderStatusRepository
{
    Task<List<GetOrderStatus>> GetOrderStatuses();
    Task<GetOrderStatus> GetOrderStatus(int id);
    Task<(Models.OrderStatus, GetOrderStatus)> AddOrderStatus(AddOrderStatus addOrderStatus);
}