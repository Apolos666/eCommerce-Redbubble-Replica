using api.DTOs.PaymentTypeDTOs;
using api.Models;
using api.Models.TypeSafe;
using api.Repositories.PaymentType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.PaymentControllers;

[Route("api/[controller]s")]
[ApiController]
[Authorize(Policy = TypeSafe.Policies.PaymentTypePolicy)]
public class PaymentTypeController : ControllerBase
{
    private readonly IPaymentTypeRepository _paymentTypeRepository;

    public PaymentTypeController(IPaymentTypeRepository paymentTypeRepository)
    {
        _paymentTypeRepository = paymentTypeRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<PaymentType>> GetAllPaymentTypes()
    {
        var paymentTypes = await _paymentTypeRepository.GetAllPaymentTypes();
        return Ok(paymentTypes);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<PaymentType>> GetPaymentTypeById([FromRoute] int id)
    {
        var paymentType = await _paymentTypeRepository.GetPaymentTypeById(id);
        
        if (paymentType is null)
            return NotFound($"Payment type with id {id} not found");
        
        return Ok(paymentType);
    }
    
    [HttpPost]
    public async Task<ActionResult<PaymentType>> AddPaymentType([FromBody] AddPaymentType addPaymentType)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var paymentType = await _paymentTypeRepository.AddPaymentType(addPaymentType);
        
        return CreatedAtAction(nameof(GetPaymentTypeById), new { id = paymentType.Id }, paymentType);
    }
}