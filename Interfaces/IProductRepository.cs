using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface IProductRepository
{
    Task AddProductAsync(Product product, CancellationToken cancellationToken = default);
    Task UpdateProductAsync(Product product, CancellationToken cancellationToken = default);
    Task DeleteProductAsync(int id, CancellationToken cancellationToken = default);
    Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Product?>> GetAllProductsAsync(CancellationToken cancellationToken = default);
    Task<List<Product?>> GetAllProductsByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);
    Task<List<Product?>> GetAllProductsBySubcategoryAsync(int subcategoryId, CancellationToken cancellationToken = default);
    Task<List<Product?>> GetAllProductsByBrandAsync(int brandId, CancellationToken cancellationToken = default);
    Task<List<Product?>> GetAllProductsBySupplierAsync(int supplierId, CancellationToken cancellationToken = default);
}