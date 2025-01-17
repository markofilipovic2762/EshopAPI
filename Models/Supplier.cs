using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopAPI.Common;

namespace EShopAPI.Models;

public class Supplier : BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(50)]
    public string? Phone { get; set; }
    [MaxLength(50)]
    public string? Email { get; set; }
    [MaxLength(50)]
    public string? Address { get; set; }
    [MaxLength(50)]
    public string? City { get; set; }
}
