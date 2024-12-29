using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Repositories;

public class ShipperRepository(ApplicationDbContext db): IShipperRepository
{
    public async Task AddShipperAsync(Shipper shipper, CancellationToken cancellationToken = default)
    {
        await db.Shippers.AddAsync(shipper, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Shipper?>> GetAllShippersAsync(CancellationToken cancellationToken = default)
    {
        return await db.Shippers.ToListAsync<Shipper?>(cancellationToken);
    }

    public async Task<Shipper?> GetShipperByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await db.Shippers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task UpdateShipperAsync(Shipper shipper, CancellationToken cancellationToken = default)
    {
        db.Shippers.Update(shipper);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteShipperAsync(int id, CancellationToken cancellationToken = default)
    {
        await db.Shippers.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }
}