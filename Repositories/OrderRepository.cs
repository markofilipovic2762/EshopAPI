using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Repositories;

public class OrderRepository(ApplicationDbContext db) : IOrderRepository
{
    public async Task<List<Order?>> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        return await db.Orders.ToListAsync<Order?>(cancellationToken);
    }

    public async Task<Order?> GetOrderAsync(int id, CancellationToken cancellationToken = default)
    {
        return await db.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task CreateOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        await db.Orders.AddAsync(order, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        db.Orders.Update(order);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteOrderAsync(int id, CancellationToken cancellationToken = default)
    {
        await db.Orders.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }
}