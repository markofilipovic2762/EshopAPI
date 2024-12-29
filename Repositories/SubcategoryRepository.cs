using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Repositories;

public class SubcategoryRepository(ApplicationDbContext db) : ISubcategoryRepository
{
    public async Task AddSubcategoryAsync(Subcategory subcategory, CancellationToken cancellationToken = default)
    {
        await db.Subcategories.AddAsync(subcategory, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateSubcategoryAsync(Subcategory subcategory, CancellationToken cancellationToken = default)
    {
        db.Subcategories.Update(subcategory);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteSubcategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        await db.Subcategories.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<Subcategory?>> GetAllSubcategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await db.Subcategories.ToListAsync<Subcategory?>(cancellationToken);
    }

    public async Task<Subcategory?> GetSubcategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await db.Subcategories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}