using EShopAPI.Models;

namespace EShopAPI.Interfaces;

public interface IEmployeeRepository
{
    Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
    Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
    Task DeleteEmployeeAsync(int id, CancellationToken cancellationToken = default);
    Task<Employee?> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Employee?>> GetAllEmployeesAsync(CancellationToken cancellationToken = default);
}