using System.ComponentModel.DataAnnotations;
using EShopAPI.Common;

namespace EShopAPI.Models;

public class Subcategory: BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}