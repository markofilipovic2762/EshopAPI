using EShopAPI.Common;
using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    
    public override int SaveChanges()
    {
        SetAuditProperties();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditProperties();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetAuditProperties()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseAuditableEntity && 
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (BaseAuditableEntity)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.Created = DateTimeOffset.UtcNow;
                entity.CreatedBy = GetCurrentUser(); // Dodajte vašu logiku za dobijanje korisnika
            }

            entity.LastModified = DateTimeOffset.UtcNow;
            entity.LastModifiedBy = GetCurrentUser(); // Dodajte vašu logiku za dobijanje korisnika
        }
    }

    private string GetCurrentUser()
    {
        // Primer: dohvatite trenutnog korisnika iz konteksta
        // Ako koristite ASP.NET Core Identity ili JWT, zamenite ovom logikom
        return "System"; // Ovde unesite korisnika koji obavlja akciju
    }
}