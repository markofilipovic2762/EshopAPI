using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Repositories;

public class SupplierRepository(ApplicationDbContext db) : ISupplierRepository
{
    public async Task AddSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default)
    {
        await db.Suppliers.AddAsync(supplier, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Supplier?>> GetAllSuppliersAsync(CancellationToken cancellationToken = default)
    {
        return await db.Suppliers.ToListAsync<Supplier?>(cancellationToken);
    }

    public async Task<Supplier?> GetSupplierByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await db.Suppliers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task UpdateSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default)
    {
        db.Suppliers.Update(supplier);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteSupplierAsync(int id, CancellationToken cancellationToken = default)
    {
        await db.Suppliers.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }
}