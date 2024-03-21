using api.DTOs.ProductImage;
using api.Repositories.ProductImage;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductImageController : ControllerBase
{
    private readonly IProductImageRepository _productImageRepository;

    public ProductImageController(IProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetProductImage>> GetAll()
    {
        var productImages = await _productImageRepository.GetAllProductImages();

        if (productImages.Count == 0)
            return NoContent();
        
        return Ok(productImages);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetProductImage>> GetProductImageById([FromRoute] int id)
    {
        var productImage = await _productImageRepository.GetProductImageById(id);

        if (productImage is null)
            return NotFound($"Product image with id {id} not found");
        
        return Ok(productImage);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetProductImage>> Add([FromBody] AddProductImage addProductImage)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (savedProductImage, getProductImage) = await _productImageRepository.AddProductImage(addProductImage); ;
        
        return CreatedAtAction(nameof(GetProductImageById), new { id = savedProductImage.Id }, getProductImage);
    }
}