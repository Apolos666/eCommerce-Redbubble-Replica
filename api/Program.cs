using api.Configurations;
using api.Models.Identity.Authentication;
using api.Services;

var builder = WebApplication.CreateBuilder(args);

var dbConfig = new DatabaseConfig();
builder.Configuration.GetSection("DatabaseConfig").Bind(dbConfig);

var jwtConfig = new JwtConfiguration();
builder.Configuration.GetSection("JwtConfig").Bind(jwtConfig);
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddApplicationRepositories(dbConfig);
builder.Services.AddApplicationServices();
builder.Services.AddApplicationIdentity();
builder.Services.AddApplicationJwtAuthentication(jwtConfig);
builder.Services.AddApplicationAuthorization();
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
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

await app.SeedDataAsync();

app.Run();