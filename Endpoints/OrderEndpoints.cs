using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Endpoints;

public static class OrderEndpoints
{
    public static RouteGroupBuilder MapOrderEndpoints(this RouteGroupBuilder group)
    {
        
        group.MapGet("/", async (IOrderRepository orders) => await orders.GetOrdersAsync());
        group.MapGet("/{id:int}", async (int id, IOrderRepository orders) => await orders.GetOrderAsync(id));
        group.MapPost("/", async ([FromBody] Order order, IOrderRepository orders) => await orders.CreateOrderAsync(order));
        group.MapPut("/", async ([FromBody] Order order, IOrderRepository orders) => await orders.UpdateOrderAsync(order));
        group.MapDelete("/{id:int}", async (int id, IOrderRepository orders) => await orders.DeleteOrderAsync(id));
        return group;
        
    }
}