using Microsoft.EntityFrameworkCore;
using QuanLyKhoHang.CategoryService.Application;
using QuanLyKhoHang.ProductService;
using QuanLyKhoHang.ProductService.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dbHost = "KIRO\\SQLEXPRESS";
var dbName = "Product";
var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; TrustServerCertificate=True ; User ID=sa; Password=123;";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ProductDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product service"); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
