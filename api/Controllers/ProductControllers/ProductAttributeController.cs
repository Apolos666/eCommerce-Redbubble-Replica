using api.DTOs.ProductAttributeDTOs;
using api.Models;
using api.Repositories.ProductAttributeModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductAttributeController : ControllerBase
{
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeController(IProductAttributeRepository productAttributeRepository)
    {
        _productAttributeRepository = productAttributeRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetProductAttribute>> GetAll([FromQuery] QueryStringParameters productAttributeParameters)
    {
        var productAttributes = await _productAttributeRepository.GetAll(productAttributeParameters);

        if (productAttributes.Count == 0)
            return NoContent();
        
        return Ok(productAttributes);
    }
    
    [HttpGet]
    [Route("product-attribute-options/{productAttributeOptionId:int}")]
    public async Task<ActionResult<GetProductAttribute>> GetProductAttributesByAttributeOptionId(int productAttributeOptionId)
    {
        var productAttributes = await _productAttributeRepository.GetAllByAttributeOptionId(productAttributeOptionId);

        if (productAttributes.Count == 0)
            return NoContent();
        
        return Ok(productAttributes);
    }
    
    [HttpGet]
    [Route("products/{productId:int}")]
    public async Task<ActionResult<GetProductAttribute>> GetProductAttributesByProductId(int productId)
    {
        var productAttributes = await _productAttributeRepository.GetAllByProductId(productId);

        if (productAttributes.Count == 0)
            return NoContent();
        
        return Ok(productAttributes);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetProductAttribute>> GetById([FromRoute] int id)
    {
        var productAttribute = await _productAttributeRepository.GetById(id);

        if (productAttribute is null)
            return NotFound($"Product attribute id: {id} not found.");
        
        return Ok(productAttribute);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetProductAttribute>> Create([FromBody] AddProductAttribute addProductAttribute)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (productAttribute, getProductAttribute) = await _productAttributeRepository.Create(addProductAttribute);

        return CreatedAtAction(nameof(GetById), new { id = productAttribute.Id }, getProductAttribute);
    }
}