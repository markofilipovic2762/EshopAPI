using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface ISupplierRepository
{
    Task AddSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default);
    Task<List<Supplier?>> GetAllSuppliersAsync(CancellationToken cancellationToken = default);
    Task<Supplier?> GetSupplierByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default);
    Task DeleteSupplierAsync(int id, CancellationToken cancellationToken = default);
}