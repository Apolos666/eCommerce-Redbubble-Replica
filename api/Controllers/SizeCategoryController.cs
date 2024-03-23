using api.DTOs.SizeCategoryDTOs;
using api.Repositories.SizeCategory;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class SizeCategoryController : ControllerBase
{
    private readonly ISizeCategoryRepository _sizeCategoryRepository;

    public SizeCategoryController(ISizeCategoryRepository sizeCategoryRepository)
    {
        _sizeCategoryRepository = sizeCategoryRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetSizeCategory>> GetAll()
    {
        var sizeCategories = await _sizeCategoryRepository.GetAll();
        
        if (sizeCategories is null)
            return NoContent();
        
        return Ok(sizeCategories);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetSizeCategory>> GetById([FromRoute] int id)
    {
        var sizeCategory = await _sizeCategoryRepository.GetSizeCategoryById(id);
        
        if (sizeCategory is null)
            return NotFound($"Size category with id {id} not found");
        
        return Ok(sizeCategory);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetSizeCategory>> Add([FromBody] AddSizeCategory addSizeCategory)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (savedSizeCategory, getSizeCategory) = await _sizeCategoryRepository.AddSizeCategory(addSizeCategory);
        
        return CreatedAtAction(nameof(GetById), new { id = savedSizeCategory.Id }, getSizeCategory);
    }
}