using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopAPI.Common;

namespace EShopAPI.Models;
public class Category: BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Subcategory> Subcategories { get; set; } = new HashSet<Subcategory>();
}
