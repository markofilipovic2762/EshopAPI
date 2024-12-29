using EShopAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using EShopAPI.Models;
namespace EShopAPI.Repositories;


public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public async Task AddCategoryAsync(Category category, CancellationToken cancellationToken)
    {
        await context.Categories.AddAsync(category,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCategoryAsync(int id)
    {
         await context.Categories.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<Category?>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await context.Categories.ToListAsync<Category?>(cancellationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    

    public async Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync(cancellationToken);
    }
}

