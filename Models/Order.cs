using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopAPI.Common;

namespace EShopAPI.Models;

public class Order : BaseAuditableEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public int? EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
    
    public decimal? TotalPrice { get;set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int? ShipVia { get; set; } 
    [MaxLength(50)]
    public string ShipName { get; set; } = null!;
    [MaxLength(50)]
    public string ShipAddress { get; set; } = null!;
    [MaxLength(50)]
    public string ShipCity { get; set; } = null!;
    public int? ShipPostalCode { get; set; }
    public virtual List<Product> Products { get; } = [];
    public virtual List<OrderDetail> OrderDetails { get; } = [];

}
