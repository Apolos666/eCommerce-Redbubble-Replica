using api.Configurations;
using api.Helper;
using api.Infrastructure.Authorization;
using api.Models.Identity.Authentication;
using api.Models.Security;
using api.Models.TypeSafe;
using api.Services;
using api.Services.ServicesRegistration;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var dbConfig = new DatabaseConfig();
builder.Configuration.GetSection("DatabaseConfig").Bind(dbConfig);

var jwtConfig = new JwtConfiguration();
builder.Configuration.GetSection("JwtConfig").Bind(jwtConfig);
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddApplicationRepositories(dbConfig);
builder.Services.AddApplicationServices();
builder.Services.AddRequirementHandler();
builder.Services.AddApplicationIdentity();
builder.Services.AddApplicationJwtAuthentication(jwtConfig);
builder.Services.AddApplicationAuthorization();
var corsConfig = new CorsConfig("VuejsWebApp", "http://localhost:5173");
builder.Services.AddCorsService(corsConfig);
builder.Services.AddThirdPartyServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseStatusCodePages();
app.UseExceptionHandler();

// app.UseExceptionHandler(exceptionHandlerApp => exceptionHandlerApp.ConfigureExceptionHandler());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseAuthentication();

app.Use(async (context, next) =>
{
    // var claims = context.User.Claims;
    //
    // var roleClaim = claims.FirstOrDefault(c => c.Type == TypeSafe.Microsoft.RolePath);
    //     
    // if (roleClaim.Value != TypeSafe.Roles.Admin)
    // {
    //     Console.WriteLine("Failed Authorization");
    //     return;
    // }
    //     
    // var permissions = claims.FirstOrDefault(c => c.Type == TypeSafe.AuthorizationPayload.Permissions);
    //     
    // if (permissions is not null)
    // {
    //     var dictPermission = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(permissions.Value);
    //         
    //     foreach (var (permissionKey, permissionValue) in dictPermission)
    //     {
    //         if (permissionKey != TypeSafe.Controller.PaymentType)
    //         {
    //             continue;
    //         }
    //             
    //         var listPermission = AuthorizeHelper.GetPermissionFromClaim(permissionValue);
    //         if (listPermission.Contains(TypeSafe.Permissions.Read) && 
    //             listPermission.Contains(TypeSafe.Permissions.Write) && 
    //             listPermission.Contains(TypeSafe.Permissions.Update) &&
    //             listPermission.Contains(TypeSafe.Permissions.Patch) &&
    //             listPermission.Contains(TypeSafe.Permissions.Delete))
    //         {
    //             Console.WriteLine("Succesful Authorization");
    //         }
    //             
    //     }
    // }
        
    await next();
});

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("VuejsWebApp");

await app.SeedDataAsync();

app.Run();