using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface IOrderRepository
{
    Task<List<Order?>> GetOrdersAsync(CancellationToken cancellationToken = default);
    Task<Order?> GetOrderAsync(int id, CancellationToken cancellationToken = default);
    Task CreateOrderAsync(Order order, CancellationToken cancellationToken = default);
    Task UpdateOrderAsync(Order order, CancellationToken cancellationToken = default);
    Task DeleteOrderAsync(int id, CancellationToken cancellationToken = default);
}