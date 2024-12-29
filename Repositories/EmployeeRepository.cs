using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Repositories;

public class EmployeeRepository(ApplicationDbContext db) : IEmployeeRepository
{
    public async Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        await db.Employees.AddAsync(employee, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        db.Employees.Update(employee);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteEmployeeAsync(int id, CancellationToken cancellationToken = default)
    {
        await db.Employees.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await db.Employees.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Employee?>> GetAllEmployeesAsync(CancellationToken cancellationToken = default)
    {
        return await db.Employees.ToListAsync<Employee?>(cancellationToken);
    }
}