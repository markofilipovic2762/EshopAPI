using EShopAPI;
using EShopAPI.Endpoints;
using EShopAPI.Identity;
using EShopAPI.Interfaces;
using EShopAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Dodavanje EF Core i baze podataka
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), optionsNpgsql =>
            optionsNpgsql.CommandTimeout(30))
        .EnableSensitiveDataLogging() //Samo u razvoju
        .LogTo(Console.WriteLine,LogLevel.Information));
//IDENTITY
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
// Dodavanje autentikacije preko JWT
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();
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

using var scope = app.Services.CreateScope();
await SeedIdentity.SeedRolesAndAdmin(scope.ServiceProvider);
//app.UseHttpsRedirection();

app.MapGroup("/categories").MapCategoryEndpoints();
app.MapGroup("/customers").MapCustomerEndpoints();
app.MapGroup("/subcategories").MapSubcategoryEndpoints();
app.MapGroup("/products").MapProductEndpoints();
app.MapGroup("/employees").MapEmployeeEndpoints();
app.MapGroup("/suppliers").MapSupplierEndpoints();
app.MapGroup("/shippers").MapShipperEndpoints();
app.MapGroup("/orders").MapOrderEndpoints();
app.MapGroup("/orderdetails").MapOrderDetailEndpoints();

app.Run();
