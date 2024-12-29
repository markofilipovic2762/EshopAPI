using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopAPI.Common;

namespace EShopAPI.Models;

public class Shipper: BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(30)]
    public string Phone { get; set; } = null!;
}
