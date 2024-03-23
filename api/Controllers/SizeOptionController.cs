using api.DTOs.SizeCategoryDTOs;
using api.DTOs.SizeOptionDTOs;
using api.Repositories.SizeCategory;
using api.Repositories.SizeOption;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class SizeOptionController : ControllerBase
{
    private readonly ISizeOptionRepository _sizeOptionRepository;

    public SizeOptionController(ISizeOptionRepository sizeOptionRepository)
    {
        _sizeOptionRepository = sizeOptionRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetSizeCategory>> GetAll()
    {
        var sizeOptions = await _sizeOptionRepository.GetAll();
        
        if (sizeOptions.Count == 0)
            return NoContent();
        
        return Ok(sizeOptions);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetSizeCategory>> GetById([FromRoute] int id)
    {
        var sizeOption = await _sizeOptionRepository.GetSizeOptionById(id);
        
        if (sizeOption is null)
            return NotFound($"Size option with id {id} not found");
        
        return Ok(sizeOption);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetSizeCategory>> Add([FromBody] AddSizeOption addSizeOption)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var (savedSizeOption, getSizeOption) = await _sizeOptionRepository.AddSizeOption(addSizeOption);
        
        return CreatedAtAction(nameof(GetById), new { id = savedSizeOption.Id }, getSizeOption);
    }
}