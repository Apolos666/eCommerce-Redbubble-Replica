using api.Configurations;
using api.Data;
using api.Models.Identity.Authentication;
using api.Repositories.AttributeTypeModel;
using api.Repositories.ColorModel;
using api.Repositories.Product;
using api.Repositories.ProductAttributeModel;
using api.Repositories.ProductAttributeOptionModel;
using api.Repositories.ProductCategory;
using api.Repositories.ProductImage;
using api.Repositories.ProductItem;
using api.Repositories.ProductSizeVariation;
using api.Repositories.SizeCategory;
using api.Repositories.SizeOption;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbConfig = new DatabaseConfig();
builder.Configuration.GetSection("DatabaseConfig").Bind(dbConfig);

var jwtConfig = new JwtConfiguration();
builder.Configuration.GetSection("JwtConfig").Bind(jwtConfig);

builder.Services.AddApplicationServices(dbConfig);
builder.Services.AddApplicationIdentity();
builder.Services.AddApplicationJwtAuthentication(jwtConfig);
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

app.Run();