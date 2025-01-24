using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Repositories;

public class ProductRepository(ApplicationDbContext db) : IProductRepository
{
    public async Task AddProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await db.Products.AddAsync(product, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        db.Products.Update(product);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteProductAsync(int id, CancellationToken cancellationToken = default)
    {
        await db.Products.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await db.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<object>> GetAllProductsAsync(CancellationToken cancellationToken = default)
    {
        return await db.Products.Select(x=> new
        {
            x.Id,
            x.Name,
            x.Description,
            x.Price,
            x.Amount,
            x.Sold,
            x.IsDeleted,
            x.ImageUrl,
            x.CategoryId,
            x.SubcategoryId,
            x.SupplierId,
            CategoryName = x.Category.Name,
            SubcategoryName = x.Subcategory.Name,
            SupplierName = x.Supplier!.Name
        }).ToListAsync<object>(cancellationToken);
    }

    public async Task<List<Product?>> GetAllProductsByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        return await db.Products.Where(x => x.CategoryId == categoryId).ToListAsync<Product?>(cancellationToken);
    }

    public async Task<List<Product?>> GetAllProductsBySubcategoryAsync(int subcategoryId, CancellationToken cancellationToken = default)
    {
        return await db.Products.Where(x => x.SubcategoryId == subcategoryId).ToListAsync<Product?>(cancellationToken);
    }

    public async Task<List<Product?>> GetAllProductsByBrandAsync(int brandId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product?>> GetAllProductsBySupplierAsync(int supplierId, CancellationToken cancellationToken = default)
    {
        return await db.Products.Where(x => x.SupplierId == supplierId).ToListAsync<Product?>(cancellationToken);
    }
}