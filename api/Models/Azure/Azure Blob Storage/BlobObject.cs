namespace api.Models.Azure.Azure_Blob_Storage;

public class BlobObject(Stream content, string contentType)
{
    public Stream? Content { get; set; } = content;
    public string? ContentType { get; set; } = contentType;
}