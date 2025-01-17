using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface ISubcategoryRepository
{
    Task AddSubcategoryAsync(Subcategory subcategory, CancellationToken cancellationToken = default);
    Task UpdateSubcategoryAsync(Subcategory subcategory, CancellationToken cancellationToken = default);
    Task DeleteSubcategoryAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Subcategory?>> GetAllSubcategoriesAsync(int? id,CancellationToken cancellationToken = default);
    Task<Subcategory?> GetSubcategoryByIdAsync(int id, CancellationToken cancellationToken = default);

    //Task<List<Subcategory?>> GetSubcategoriesByCategory(int id, CancellationToken cancellationToken = default);
}