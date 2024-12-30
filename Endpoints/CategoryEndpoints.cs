using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Endpoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoryEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/",async (ICategoryRepository categories) => await categories.GetAllCategoriesAsync());
        group.MapGet("/{id:int}", async (int id, ICategoryRepository categories) => await categories.GetCategoryByIdAsync(id));
        group.MapPost("/", async ([FromBody] Category category, ICategoryRepository categories) =>
        {
            await categories.AddCategoryAsync(category);
            return Results.Created("/categories/" + category.Id, category);
        }).Accepts<Category>("application/json");
        group.MapPut("/", async ([FromBody] Category category, ICategoryRepository categories) =>
        {
            await categories.UpdateCategoryAsync(category);
            return Results.Ok(category);
        });
        group.MapDelete("/{id:int}", async (int id, ICategoryRepository categories) =>
        {
            await categories.DeleteCategoryAsync(id);
            return Results.Ok();
        });
        
        return group;
    }
}