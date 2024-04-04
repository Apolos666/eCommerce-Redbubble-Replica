using api.DTOs.ProductItemDTOs;
using api.Repositories.ProductItem;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductItemController : ControllerBase
{
    private readonly IProductItemRepository _productItemRepository;

    public ProductItemController(IProductItemRepository productItemRepository)
    {
        _productItemRepository = productItemRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetProductItem>>> GetAll()
    {
        var productItems = await _productItemRepository.GetAll();
        
        if (productItems.Count == 0)
            return NoContent();
        
        return Ok(productItems);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetProductItem>> GetById([FromRoute] int id)
    {
        var productItem = await _productItemRepository.GetProductItemById(id);
        
        if (productItem is null)
            return NotFound($"Product item with id {id} not found");
        
        return Ok(productItem);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetProductItem>> Add([FromBody] AddProductItem addProductItem)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (savedProductItem, getProductItem) = await _productItemRepository.AddProductItem(addProductItem);
        
        return CreatedAtAction(nameof(GetById), new { id = savedProductItem.Id }, getProductItem);
    }
}