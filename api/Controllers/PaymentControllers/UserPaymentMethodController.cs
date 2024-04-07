using api.DTOs.Payment_DTOs.UserPaymentMethodDTOs;
using api.Models;
using api.Models.TypeSafe;
using api.Repositories.Payment_Repositories.UserPaymentMethod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.PaymentControllers;

[Route("api/[controller]s")]
[ApiController]
[Authorize(Policy = TypeSafe.Policies.UserPaymentMethod)]
public class UserPaymentMethodController : ControllerBase
{
    private readonly IUserPaymentMethodRepository _userPaymentMethodRepository;

    public UserPaymentMethodController(IUserPaymentMethodRepository userPaymentMethodRepository)
    {
        _userPaymentMethodRepository = userPaymentMethodRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUserPaymentMethods([FromQuery] UserPaymentMethodParameters queryParameters)
    {
        var userPaymentMethods = await _userPaymentMethodRepository.GetAllUserPaymentMethods(queryParameters);
        
        if (userPaymentMethods.Count == 0)
            return NoContent();
        
        return Ok(userPaymentMethods);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetUserPaymentMethodById([FromRoute] int id)
    {
        var userPaymentMethod = await _userPaymentMethodRepository.GetUserPaymentMethodById(id);
        
        if (userPaymentMethod is null)
            return NotFound("User payment method not found");
        
        return Ok(userPaymentMethod);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUserPaymentMethod([FromBody] AddUserPaymentMethod addUserPaymentMethod)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (userPaymentMethod, getUserPaymentMethod) = await _userPaymentMethodRepository.AddUserPaymentMethod(addUserPaymentMethod);
        
        return CreatedAtAction(nameof(GetUserPaymentMethodById), new { id = userPaymentMethod.Id }, getUserPaymentMethod);
    }
}