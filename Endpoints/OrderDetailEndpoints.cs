using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Endpoints;

public static class OrderDetailEndpoints
{
    public static RouteGroupBuilder MapOrderDetailEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IOrderDetailRepository orderDetails) => await orderDetails.GetAllOrderDetailsAsync());
        group.MapGet("/{id:int}", async (int id, IOrderDetailRepository orderDetails) => await orderDetails.GetOrderDetailByIdAsync(id));
        group.MapPost("/", async ([FromBody] OrderDetail orderDetail, IOrderDetailRepository orderDetails) => await orderDetails.AddOrderDetailAsync(orderDetail));
        group.MapPut("/", async ([FromBody] OrderDetail orderDetail, IOrderDetailRepository orderDetails) => await orderDetails.UpdateOrderDetailAsync(orderDetail));
        group.MapDelete("/{id:int}", async (int id, IOrderDetailRepository orderDetails) => await orderDetails.DeleteOrderDetailAsync(id));
        return group;
    }
}