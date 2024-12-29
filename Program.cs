using EShopAPI;
using EShopAPI.Endpoints;
using EShopAPI.Interfaces;
using EShopAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Dodavanje EF Core i konekcionog stringa
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), optionsNpgsql =>
            optionsNpgsql.CommandTimeout(30))
        .EnableSensitiveDataLogging() //Samo u razvoju
        .LogTo(Console.WriteLine,LogLevel.Information));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

builder.Services.AddOpenApi();
builder.Logging.ClearProviders(); // Uklanja postojeće log providere
builder.Logging.AddSerilog(); // Dodaje Serilog kao logger
builder.Host.UseSerilog(); // Postavlja Serilog kao default logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.WithProperty("ApplicationName", "Eshop")
    .CreateLogger();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Eshop API")
            .WithTheme(ScalarTheme.Saturn)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    } );
}

//app.UseHttpsRedirection();

app.MapGroup("/categories").MapCategoryEndpoints();

app.Run();
