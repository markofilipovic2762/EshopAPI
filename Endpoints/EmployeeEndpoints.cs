using EShopAPI.Interfaces;
using EShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Endpoints;

public static class EmployeeEndpoints
{
    public static RouteGroupBuilder MapEmployeeEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IEmployeeRepository employees) => await employees.GetAllEmployeesAsync());
        group.MapGet("/{id:int}", async (int id, IEmployeeRepository employees) => await employees.GetEmployeeByIdAsync(id));
        group.MapPost("/", async ([FromBody] Employee employee, IEmployeeRepository employees) => await employees.AddEmployeeAsync(employee));
        group.MapPut("/", async ([FromBody] Employee employee, IEmployeeRepository employees) => await employees.UpdateEmployeeAsync(employee));
        group.MapDelete("/", async (int id, IEmployeeRepository employees) => await employees.DeleteEmployeeAsync(id));
        return group;
    }
}