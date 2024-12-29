namespace EShopAPI.Common;

public abstract class BaseAuditableEntity
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}