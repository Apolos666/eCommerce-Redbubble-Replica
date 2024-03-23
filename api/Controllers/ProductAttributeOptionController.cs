using api.DTOs.ProductAttributeOptionDTOs;
using api.Repositories.ProductAttributeOptionModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductAttributeOptionController : ControllerBase
{
    private readonly IProductAttributeOptionRepository _productAttributeOptionRepository;

    public ProductAttributeOptionController(IProductAttributeOptionRepository productAttributeOptionRepository)
    {
        _productAttributeOptionRepository = productAttributeOptionRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetProductAttributeOption>> GetAll()
    {
        var productAttributeOptions = await _productAttributeOptionRepository.GetAll();
        
        if (productAttributeOptions.Count == 0)
            return NoContent();
        
        return Ok(productAttributeOptions);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetProductAttributeOption>> GetById([FromRoute] int id)
    {
        var productAttributeOption = await _productAttributeOptionRepository.GetProductAttributeOptionById(id);
        
        if (productAttributeOption is null)
            return NotFound($"Product attribute option with id {id} not found");
        
        return Ok(productAttributeOption);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetProductAttributeOption>> Add([FromBody] AddProductAttributeOption addProductAttributeOption)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (savedProductAttributeOption, getProductAttributeOption) = await _productAttributeOptionRepository.AddProductAttributeOption(addProductAttributeOption);
        
        return CreatedAtAction(nameof(GetById), new { id = savedProductAttributeOption.Id }, getProductAttributeOption);
    }
}