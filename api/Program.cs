using api.Configurations;
using api.Data;
using api.Repositories.AttributeTypeModel;
using api.Repositories.ColorModel;
using api.Repositories.ProductCategory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
     
var dbConfig = new DatabaseConfig(); 
builder.Configuration.GetSection("DatabaseConfig").Bind(dbConfig);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(dbConfig.ConnectionString);
    options.EnableDetailedErrors(dbConfig.DetailedErrors); // DetailedErrors is true in development
    options.EnableSensitiveDataLogging(dbConfig.SensitiveDataLogging); // SensitiveDataLogging is true in development
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IColorModelRepository, ColorModelRepository>();
builder.Services.AddScoped<IProductAttributeTypeRepository, ProductAttributeTypeRepository>();

var app = builder.Build();

app.UseStatusCodePages();
app.UseExceptionHandler();

// app.UseExceptionHandler(exceptionHandlerApp => exceptionHandlerApp.ConfigureExceptionHandler());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
