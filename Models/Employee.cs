
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EShopAPI.Common;
namespace EShopAPI.Models;

public class Employee: BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    [MaxLength(50)]
    public string? Email { get; set; }
    public DateOnly? BirthDate { get; set; }
    public DateOnly? HireDate { get; set; }
    [MaxLength(50)]
    public string Address { get; set; } = null!;
    [MaxLength(30)]
    public string City { get; set; } = null!;
    public int? SuperiorId { get; set; }

    [ForeignKey("SuperiorId")]
    public virtual Employee? Superior { get; set; }
    public byte[]? Photo { get; set; }

}
