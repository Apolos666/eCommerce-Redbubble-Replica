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
// builder.Services.AddCookiePolicy();
builder.Services.AddApplicationJwtAuthentication(jwtConfig);
builder.Services.AddApplicationAuthorization();
var corsConfig = new CorsConfig("VuejsWebApp", "http://localhost:5173");
builder.Services.AddCorsService(corsConfig);
builder.Services.AddThirdPartyServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddHttpContextAccessor();
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

app.UseCors("VuejsWebApp");

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

await app.SeedDataAsync();

app.Run();