using api.DTOs.ShippingMethodDTOs;
using api.Models.TypeSafe;
using api.Repositories.ShippingMethod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.OrderControllers;

[Route("api/[controller]s")]
[ApiController]
[Authorize(Policy = TypeSafe.Policies.ShippingMethodPolicy)]
public class ShippingMethodController : ControllerBase
{
    private readonly IShippingMethodRepository _shippingMethodRepository;

    public ShippingMethodController(IShippingMethodRepository shippingMethodRepository)
    {
        _shippingMethodRepository = shippingMethodRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetShippingMethod>>> GetAllShippingMethod()
    {
        var shippingMethods = await _shippingMethodRepository.GetShippingMethods();
        
        if (shippingMethods.Count == 0)
            return NoContent();
        
        return Ok(shippingMethods);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetShippingMethod>> GetShippingMethodById([FromRoute] int id)
    {
        var shippingMethod = await _shippingMethodRepository.GetShippingMethod(id);
        
        if (shippingMethod is null)
            return NotFound($"Shipping method with id {id} not found");
        
        return Ok(shippingMethod);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetShippingMethod>> AddShippingMethod([FromBody] AddShippingMethod addShippingMethod)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (savedShippingMethod, getShippingMethod) = await _shippingMethodRepository.AddShippingMethod(addShippingMethod);
        
        return CreatedAtAction(nameof(GetShippingMethodById), new { id = savedShippingMethod.Id }, getShippingMethod);
    }
}