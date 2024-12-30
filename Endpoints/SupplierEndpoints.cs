using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Endpoints;

public static class SupplierEndpoints
{
    public static RouteGroupBuilder MapSupplierEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (ISupplierRepository suppliers) => await suppliers.GetAllSuppliersAsync());
        group.MapGet("/{id:int}", async (int id, ISupplierRepository suppliers) => await suppliers.GetSupplierByIdAsync(id));
        group.MapPost("/", async ([FromBody] Supplier supplier, ISupplierRepository suppliers) => await suppliers.AddSupplierAsync(supplier));
        group.MapPut("/", async ([FromBody] Supplier supplier, ISupplierRepository suppliers) => await suppliers.UpdateSupplierAsync(supplier));
        group.MapDelete("/{id:int}", async (int id, ISupplierRepository suppliers) => await suppliers.DeleteSupplierAsync(id));
        return group;
    }
}