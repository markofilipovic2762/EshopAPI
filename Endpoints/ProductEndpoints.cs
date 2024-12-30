using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        return group;
    }
}