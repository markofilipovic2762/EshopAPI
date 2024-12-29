using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopAPI.Common;

namespace EShopAPI.Models;

public class OrderDetail: BaseAuditableEntity
{
    public int OrderId {  get; set; }
    public virtual Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public DateTime TimeOfOrder { get; set; }
    public decimal? Discount { get; set; } = 0;

}
