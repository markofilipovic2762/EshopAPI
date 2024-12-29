using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Customer?>> GetAllCustomersAsync(CancellationToken cancellationToken = default);
    Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
    Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
}