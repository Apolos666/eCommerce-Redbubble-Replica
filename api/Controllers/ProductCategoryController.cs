﻿using api.Repositories.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productCategories = await _productCategoryRepository.GetAll();

        if (productCategories is null)
            return NotFound();
        
        return Ok(productCategories);
    }
}