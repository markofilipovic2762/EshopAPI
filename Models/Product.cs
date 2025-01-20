using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopAPI.Common;

namespace EShopAPI.Models;

public class Product:BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(200)]
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Amount { get; set; } = 0;
    public int? Sold { get; set; } = 0;
    public bool? IsDeleted { get; set; } = false;
    public int CategoryId { get; set; }
    public int SubcategoryId {  get; set; }
    public int? SupplierId {  get; set; }
    [MaxLength(100)]
    public string? ImageUrl { get; set; }
    public virtual Category Category { get; set; } = null!;
    public virtual Subcategory Subcategory { get; set; } = null!;
    public virtual Supplier? Supplier { get; set; }

    public virtual List<Order> Orders { get; } = [];
    public virtual List<OrderDetail> OrderDetails { get; } = [];

}
