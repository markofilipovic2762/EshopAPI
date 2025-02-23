using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EShopAPI.Endpoints;

public static class ProductEndpoints
{
    public static RouteGroupBuilder MapProductEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IProductRepository products) => await products.GetAllProductsAsync());
        group.MapGet("/{id:int}",
            async (int id, IProductRepository products) => await products.GetProductByIdAsync(id));
        group.MapGet("/{id:int}/supplier",
            async (int id, IProductRepository products) => await products.GetAllProductsBySupplierAsync(id));
        group.MapGet("/{id:int}/category",
            async (int id, IProductRepository products) => await products.GetAllProductsByCategoryAsync(id));
        group.MapGet("/{id:int}/subcategory",
            async (int id, IProductRepository products) => await products.GetAllProductsBySubcategoryAsync(id));
        group.MapPost("/",
            async ([FromBody] Product product, IProductRepository products) => await products.AddProductAsync(product));
        group.MapPut("/",
            async ([FromBody] Product product, IProductRepository products) =>
            await products.UpdateProductAsync(product));
        group.MapDelete("/{id:int}", async (int id, IProductRepository products) => await products.DeleteProductAsync(id));
        group.MapPost("/upload", async (IFormFile file) =>
        {
            if (file == null || file.Length == 0)
            {
                return Results.BadRequest("Invalid file.");
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            Log.Information("FileExtension is {FileExtension}, filename is {FileName}", fileExtension, file.FileName);

            if (!allowedExtensions.Contains(fileExtension))
            {
                return Results.BadRequest("File type not supported.");
            }

            var allowedMimeTypes = new[] { "image/jpeg", "image/png" };
            Log.Information("Tip fajla je {TipFajla}", file.ContentType);
            if (!allowedMimeTypes.Contains(file.ContentType))
            {
                return Results.BadRequest("Invalid file type.");
            }

            // Čuvanje fajla u lokalni fajl sistem ili cloud
            /*var uploadDirectory = Path.Combine("D:\\marko\\EShopAPI\\EshopAPI\\Uploads");*/
            var uploadDirectory = Path.Combine(Environment.CurrentDirectory, "Uploads");
            var fileName = Guid.NewGuid() + fileExtension;
            var filePath = Path.Combine(uploadDirectory, fileName);
            
            // Proverite i kreirajte direktorijum ako ne postoji
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"/uploads/{fileName}";

            return Results.Ok(new { Url = fileUrl });
        }).DisableAntiforgery();
        return group;
    }
}