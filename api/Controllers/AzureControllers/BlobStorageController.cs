using api.Services.AzureServices.BlobStrorage;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.AzureControllers;

[ApiController]
[Route("api/[controller]")]
public class BlobStorageController : ControllerBase
{
    private readonly IBlobServices _blobServices;

    public BlobStorageController(IBlobServices blobServices)
    {
        _blobServices = blobServices;
    }
    
    [HttpPost("create-container")]
    public async Task<IActionResult> CreateContainer()
    {
        var container = await _blobServices.CreateSampleContainerAsync();
        return Ok(container);
    }
    
    [HttpPost("create-root-container")]
    public IActionResult CreateRootContainer()
    {
        _blobServices.CreateRootContainerAsync();
        return Ok();
    }
    
    [HttpDelete("delete-container")]
    public async Task<IActionResult> DeleteContainer([FromQuery] string containerName)
    {
        await _blobServices.DeleteSampleContainerAsync(containerName);
        return Ok();
    }
}