namespace api.Services.ServicesRegistration;

public static class ConfigurationService
{
    public static IServiceCollection AddCookiePolicy(this IServiceCollection service)
    {
        service.Configure<CookiePolicyOptions>(options =>
        { 
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
        
        return service;
    }
}