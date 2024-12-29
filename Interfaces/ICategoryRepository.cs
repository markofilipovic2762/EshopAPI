using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category, CancellationToken cancellationToken = default);
    Task DeleteCategoryAsync(int id);
    Task<List<Category?>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);
}