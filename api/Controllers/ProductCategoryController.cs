﻿using api.DTOs.ProductCategoryDTOs;
using api.Repositories.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetProductCategory>> GetAll()
    {
        var productCategories = await _productCategoryRepository.GetAll();

        if (productCategories.Count == 0)
            return NoContent();
        
        return Ok(productCategories);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetProductCategory>> GetProductCategoryById([FromRoute] int id)
    {
        var productCategory = await _productCategoryRepository.GetProductCategoryById(id);

        if (productCategory is null)
            return NotFound($"Product category with id {id} not found");
        
        return Ok(productCategory);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetProductCategory>> Add([FromBody] AddProductCategory addProductCategory)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (savedProductCategory, getProductCategory) = await _productCategoryRepository.AddProductCategory(addProductCategory); ;
        
        return CreatedAtAction(nameof(GetProductCategoryById), new { id = savedProductCategory.ProductCategoryId }, getProductCategory);
    }
}