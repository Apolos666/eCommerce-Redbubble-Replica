using api.DTOs.Order_DTOs.OrderStatusDTOs;
using api.Models.TypeSafe;
using api.Repositories.Order_Repositories.OrderStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.OrderControllers;

[Route("api/[controller]s")]
[ApiController]
[Authorize(Policy = TypeSafe.Policies.OrderStatus)]
public class OrderStatusController : ControllerBase
{
    private readonly IOrderStatusRepository _orderStatusRepository;

    public OrderStatusController(IOrderStatusRepository orderStatusRepository)
    {
        _orderStatusRepository = orderStatusRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetOrderStatus>>> GetAllOrderStatus()
    {
        var orderStatuses = await _orderStatusRepository.GetOrderStatuses();
        
        if (orderStatuses.Count == 0)
            return NoContent();
        
        return Ok(orderStatuses);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetOrderStatus>> GetOrderStatusById([FromRoute] int id)
    {
        var orderStatus = await _orderStatusRepository.GetOrderStatus(id);
        
        if (orderStatus is null)
            return NotFound($"Order Status with id {id} not found");
        
        return Ok(orderStatus);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetOrderStatus>> AddOrderStatus([FromBody] AddOrderStatus addShippingMethod)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (orderStatus, getOrderStatus) = await _orderStatusRepository.AddOrderStatus(addShippingMethod);
        
        return CreatedAtAction(nameof(GetOrderStatusById), new { id = orderStatus.Id }, getOrderStatus);
    }
}