using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface IOrderDetailRepository
{
    Task AddOrderDetailAsync(OrderDetail orderDetail, CancellationToken cancellationToken = default);
    Task UpdateOrderDetailAsync(OrderDetail orderDetail, CancellationToken cancellationToken = default);
    Task DeleteOrderDetailAsync(int id, CancellationToken cancellationToken = default);
    Task<OrderDetail?> GetOrderDetailByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<OrderDetail?>> GetAllOrderDetailsAsync(CancellationToken cancellationToken = default);
}