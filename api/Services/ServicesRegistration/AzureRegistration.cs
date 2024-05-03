using api.Models.Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
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

    public static SecretClient AddKeyVault(this WebApplicationBuilder builder)
    {
        var keyVault = new KeyVault
        {
            KeyVaultURL = builder.Configuration["KeyVaultURL"],
            ClientId = builder.Configuration["ClientId"],
            ClientSecret = builder.Configuration["ClientSecret"],
            DirectoryId = builder.Configuration["DirectoryId"]
        };
        var credential = new ClientSecretCredential(keyVault.DirectoryId, keyVault.ClientId, keyVault.ClientSecret);
        builder.Configuration.AddAzureKeyVault(new Uri(keyVault.KeyVaultURL), credential);
        var secretClient = new SecretClient(new Uri(keyVault.KeyVaultURL), credential);

        builder.Services.AddSingleton(secretClient);

        return secretClient;
    }
}