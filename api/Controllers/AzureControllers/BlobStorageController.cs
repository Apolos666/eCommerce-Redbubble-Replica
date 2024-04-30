using api.Models.Azure.Azure_Blob_Storage;
using api.Services.AzureServices.BlobStrorage;
using Azure.Storage.Blobs;
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
    
    [HttpPost]
    [Route("uploadblobfile")]
    public async Task<IActionResult> UploadBlobFile([FromBody] BlobContentModel model)
    {
        var result = await _blobServices.UploadBlobFileAsync("user-profile-" ,model.FilePath, model.FileName);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("listblobs")]
    public async Task<IActionResult> ListBlobs()
    {
        var result = await _blobServices.ListBlobs();

        return Ok(result);
    }
    
    [HttpGet]
    [Route("getblobfile")]
    public async Task<IActionResult> GetBlobFile([FromQuery] string url)
    {
        BlobObject result = await _blobServices.GetBlobFile(url);

        return File(result.Content, result.ContentType);
    }
    
    [HttpDelete]
    [Route("deleteblobfile")]
    public IActionResult DeleteBlobFile([FromQuery] string url)
    {
        _blobServices.DeleteBlob(url);
        return Ok();
    }
}