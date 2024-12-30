using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Endpoints;

public static class SubcategoryEndpoints
{
    public static RouteGroupBuilder MapSubcategoryEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (ISubcategoryRepository subcategories) => await subcategories.GetAllSubcategoriesAsync());
        group.MapGet("/{id:int}", async (int id, ISubcategoryRepository subcategories) => await subcategories.GetSubcategoryByIdAsync(id));
        group.MapPost("/", async ([FromBody] Subcategory subcategory, ISubcategoryRepository subcategories) => await subcategories.AddSubcategoryAsync(subcategory));
        group.MapPut("/", async ([FromBody] Subcategory subcategory, ISubcategoryRepository subcategories) => await subcategories.UpdateSubcategoryAsync(subcategory));
        group.MapDelete("/{id:int}", async (int id, ISubcategoryRepository subcategories) => await subcategories.DeleteSubcategoryAsync(id));
        return group;
    }   
}