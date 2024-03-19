using api.DTOs.AttributeTypeModelDTOs;
using api.Models;
using api.Repositories.AttributeTypeModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductAttributeTypeController : ControllerBase
{
    private readonly IProductAttributeTypeRepository _productAttributeTypeRepository;

    public ProductAttributeTypeController(IProductAttributeTypeRepository productAttributeTypeRepository)
    {
        _productAttributeTypeRepository = productAttributeTypeRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetProductAttributeType>>> GetAll()
    {
        var attributeTypes = await _productAttributeTypeRepository.GetAll();

        if (attributeTypes is null)
            return NotFound("No product attribute types found.");
        
        return Ok(attributeTypes);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ProductAttributeType>> GetById([FromRoute] int id)
    {
        var attributeType = await _productAttributeTypeRepository.GetById(id);

        if (attributeType is null)
            return NotFound($"Product attribute type with id {id} not found.");
        
        return Ok(attributeType);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetProductAttributeType>> Add([FromBody] AddProductAttributeType addProductAttributeType)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var savedAttributeType = await _productAttributeTypeRepository.Add(addProductAttributeType);
        
        if (savedAttributeType is null)
            return BadRequest("An error occurred while adding the product attribute type");
        
        return CreatedAtAction(nameof(GetById), new { id = savedAttributeType.Id}, savedAttributeType);
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<GetProductAttributeType>> Update([FromRoute] int id, [FromBody] UpdateProductAttributeType updateProductAttributeType)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var updatedAttributeType = await _productAttributeTypeRepository.Update(id, updateProductAttributeType);
        
        if (updatedAttributeType is null)
            return BadRequest("An error occurred while updating the product attribute type");
        
        return Ok(updatedAttributeType);
    }
}