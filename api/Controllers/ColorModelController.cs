using api.DTOs.ColorModelDTOs;
using api.Repositories.ColorModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ColorModelController : ControllerBase
{
    private readonly IColorModelRepository _colorModelRepository;

    public ColorModelController(IColorModelRepository colorModelRepository)
    {
        _colorModelRepository = colorModelRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetColorModel>> GetAll()
    {
        var colorModels = await _colorModelRepository.GetAll();

        if (colorModels is null)
            return NotFound();
        
        return Ok(colorModels);
    }
    
    [HttpGet]
    [Route("{colorName}")]
    public async Task<ActionResult<GetColorModel>> GetColorByName([FromRoute] string colorName)
    {
        var colorModel = await _colorModelRepository.GetColorByName(colorName);

        if (colorModel is null)
            return NotFound($"Color with name {colorName} not found");
        
        return Ok(colorModel);
    }
    
    [HttpGet]
    [Route("colorHex/{colorHexCode}")]
    public async Task<ActionResult<GetColorModel>> GetColorByColorHex([FromRoute] string colorHexCode)
    {
        var colorModel = await _colorModelRepository.GetColorByColorHex(colorHexCode);

        if (colorModel is null)
            return NotFound($"Color with hex code {colorHexCode} not found");
        
        return Ok(colorModel);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetColorModel>> Add([FromBody] AddColorModel addColorModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var savedColorModel = await _colorModelRepository.Add(addColorModel);
        
        if (savedColorModel is null)
            return BadRequest("ColorModel could not be saved.");

        return CreatedAtAction(nameof(GetColorByName), new { colorName = savedColorModel.ColorName }, savedColorModel);
    }
    
    [HttpPut]
    [Route("updateColorNameBasedOnColorHex/{colorHex}")]
    public async Task<ActionResult<GetColorModel>> UpdateColorNameBasedOnColorHex([FromRoute] string colorHex, [FromBody] UpdateColorModelName updateColorModelName)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var updatedColorModel = await _colorModelRepository.UpdateColorNameBasedOnColorHex(colorHex, updateColorModelName);

        if (updatedColorModel is null)
            return NotFound($"Color with hex code {colorHex} not found");
        
        return Ok(updatedColorModel);
    }
    
    [HttpPut]
    [Route("updateColorHexBasedOnColorName/{colorName}")]
    public async Task<ActionResult<GetColorModel>> UpdateColorHexBasedOnColorName([FromRoute] string colorName, [FromBody] UpdateColorModelHex updateColorModelHex)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var updatedColorModel = await _colorModelRepository.UpdateColorHexBasedOnColorName(colorName, updateColorModelHex);

        if (updatedColorModel is null)
            return NotFound($"Color with name {colorName} not found");
        
        return Ok(updatedColorModel);
    }
}