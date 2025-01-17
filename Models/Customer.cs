using System.ComponentModel.DataAnnotations;
using EShopAPI.Common;

namespace EShopAPI.Models;

public class Customer:BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(100)]
    public string? Address { get; set; }
    [MaxLength(50)]
    public string? City {  get; set; }
    public int? PostalCode { get; set; }
    [MaxLength(20)]
    public string? Phone { get; set; }
    [MaxLength(50)]
    public string? Email { get; set; }

}
