using api.DTOs.ProductDTOs;
using api.Models.TypeSafe;
using api.Repositories.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetProduct>> GetAll()
    {
        var products = await _productRepository.GetAll();

        if (products.Count == 0)
            return NoContent();
        
        return Ok(products);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetProduct>> GetProductById([FromRoute] int id)
    {
        var product = await _productRepository.GetProductById(id);

        if (product is null)
            return NotFound($"Product with id {id} not found");
        
        return Ok(product);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetProduct>> Add([FromBody] AddProduct addProduct)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (savedProduct, getProduct) = await _productRepository.AddProduct(addProduct);
        
        return CreatedAtAction(nameof(GetProductById), new { id = savedProduct.ProductId }, getProduct);
    }
}