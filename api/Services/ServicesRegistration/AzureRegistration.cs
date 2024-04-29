using Azure.Identity;
using Microsoft.Extensions.Azure;

namespace api.Services.AzureServices;

public static class AzureRegistration
{
    public static IServiceCollection AddAzureServices(this IServiceCollection services)
    {
        services.AddAzureClients(x =>
        {
            x.AddBlobServiceClient(new Uri("https://imagesrebbuble.blob.core.windows.net"));
            x.UseCredential(new DefaultAzureCredential());
        });
        
        return services;
    }
}