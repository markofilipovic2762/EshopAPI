using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Repositories;

public class OrderDetailRepository(ApplicationDbContext db) : IOrderDetailRepository
{
    public async Task AddOrderDetailAsync(OrderDetail orderDetail, CancellationToken cancellationToken = default)
    {
        await db.OrderDetails.AddAsync(orderDetail, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateOrderDetailAsync(OrderDetail orderDetail, CancellationToken cancellationToken = default)
    {
        db.OrderDetails.Update(orderDetail);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteOrderDetailAsync(int id, CancellationToken cancellationToken = default)
    {
        await db.OrderDetails.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<OrderDetail?> GetOrderDetailByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await db.OrderDetails.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<OrderDetail?>> GetAllOrderDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await db.OrderDetails.ToListAsync<OrderDetail?>(cancellationToken);
    }
}