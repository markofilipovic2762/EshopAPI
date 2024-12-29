using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface IShipperRepository
{
    Task AddShipperAsync(Shipper shipper, CancellationToken cancellationToken = default);
    Task<List<Shipper?>> GetAllShippersAsync(CancellationToken cancellationToken = default);
    Task<Shipper?> GetShipperByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateShipperAsync(Shipper shipper, CancellationToken cancellationToken = default);
    Task DeleteShipperAsync(int id, CancellationToken cancellationToken = default);
}