using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Repositories;

public class CustomerRepository(ApplicationDbContext db): ICustomerRepository
{
    public async Task<Customer?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await db.Customers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Customer?>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
    {
        return await db.Customers.ToListAsync<Customer?>(cancellationToken);
    }

    public async Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        await db.Customers.AddAsync(customer, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default)
    {
        await db.Customers.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        db.Customers.Update(customer);
        await db.SaveChangesAsync(cancellationToken);
    }
}