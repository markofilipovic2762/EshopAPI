using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Endpoints;

public static class CustomerEndpoints
{
    public static RouteGroupBuilder MapCustomerEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (ICustomerRepository customers) => await customers.GetAllCustomersAsync());
        group.MapGet("/{id:int}", async (int id, ICustomerRepository customers) => await customers.GetCustomerByIdAsync(id));
        group.MapPost("/", async ([FromBody] Customer customer, ICustomerRepository customers) => await customers.AddCustomerAsync(customer));
        group.MapPut("/", async ([FromBody] Customer customer, ICustomerRepository customers) => await customers.UpdateCustomerAsync(customer));
        group.MapDelete("/", async (int id, ICustomerRepository customers) => await customers.DeleteCustomerAsync(id));
        return group;
    }
}