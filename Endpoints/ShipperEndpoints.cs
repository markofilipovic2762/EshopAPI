using EShopAPI.Interfaces;
using EShopAPI.Models;

namespace EShopAPI.Endpoints;

public static class ShipperEndpoints
{
    public static RouteGroupBuilder MapShipperEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IShipperRepository shipperRepository) => await shipperRepository.GetAllShippersAsync());
        group.MapGet("/{int:id}", async (int id, IShipperRepository shipperRepository) => await shipperRepository.GetShipperByIdAsync(id));
        group.MapPost("/", async (Shipper shipper, IShipperRepository shipperRepository) => await shipperRepository.AddShipperAsync(shipper));
        group.MapPut("/", async (Shipper shipper, IShipperRepository shipperRepository) => await shipperRepository.UpdateShipperAsync(shipper));
        group.MapDelete("/", async (int id, IShipperRepository shipperRepository) => await shipperRepository.DeleteShipperAsync(id));
        return group;
    }
}