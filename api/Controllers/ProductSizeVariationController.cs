using api.DTOs.ProductSizeVariationDTOs;
using api.Models;
using api.Repositories.ProductSizeVariation;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductSizeVariationController : ControllerBase
{
    private readonly IProductSizeVariationRepository _productSizeVariationRepository;

    public ProductSizeVariationController(IProductSizeVariationRepository productSizeVariationRepository)
    {
        _productSizeVariationRepository = productSizeVariationRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetProductSizeVariation>> GetAll([FromQuery] QueryStringParameters productSizeVariationParameters)
    {
        var productSizeVariations = await _productSizeVariationRepository.GetAll(productSizeVariationParameters);

        if (productSizeVariations.Count == 0)
            return NoContent();
        
        return Ok(productSizeVariations);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetProductSizeVariation>> GetProductSizeVariationById(int id)
    {
        var productSizeVariation = await _productSizeVariationRepository.GetById(id);
        
        if (productSizeVariation is null)
            return NotFound($"Product size id:{id} variation not found.");
        
        return Ok(productSizeVariation);
    }
    
    [HttpGet]
    [Route("product-items/{productItemId}")]
    public async Task<ActionResult<GetProductSizeVariation>> GetProductSizeVariationsByProductItemId(int productItemId)
    {
        var productSizeVariation = await _productSizeVariationRepository.GetAllByProductItemId(productItemId);
        
        if (productSizeVariation.Count == 0)
            return NoContent();
        
        return Ok(productSizeVariation);
    }
    
    [HttpGet]
    [Route("size-options/{sizeOptionsId}")]
    public async Task<ActionResult<GetProductSizeVariation>> GetProductSizeVariationsBySizeOptionId(int sizeOptionsId)
    {
        var productSizeVariation = await _productSizeVariationRepository.GetAllBySizeOptionsId(sizeOptionsId);
        
        if (productSizeVariation.Count == 0)
            return NoContent();
        
        return Ok(productSizeVariation);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetProductSizeVariation>> AddProductSizeVariation([FromBody] AddProductSizeVariation addProductSizeVariation)
    {
        var (productSizeVariation, getProductSizeVariation) = await _productSizeVariationRepository.Create(addProductSizeVariation);

        return CreatedAtAction(nameof(GetProductSizeVariationById), new { id = productSizeVariation.Id }, getProductSizeVariation);
    }
}